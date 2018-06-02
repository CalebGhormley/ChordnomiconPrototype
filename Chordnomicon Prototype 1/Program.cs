using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            bool exit = false;
            Progression progression = new Progression();
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            System.Console.WriteLine("------------Chordnomicon-----------" +
                               "\nThis is an application that helps" +
                               "\ncomposers write chord progresssions ");
            while (exit == false)
            {
                System.Console.WriteLine("\nThe current key is: " + progression.getKey().getName() +
                               "\n The current mode is: " + progression.getMode().getName() +
                               "\n The current tuning is: " + progression.getTuning());
                if (progression.getSize() == 0)
                { System.Console.WriteLine("There are no chords in your progression"); }
                else
                { System.Console.WriteLine("The current chords in your progression are: \n" + progression.getChordNames()); }
                System.Console.WriteLine("\nWhat would you like to do?" +
                               "\n1) Change the key, mode or tuning" +
                               "\n2) Add or modify a chord" +
                               "\n3) View tablature of current chords" +
                               "\n4) Quit the program");
                answer = System.Console.ReadLine();
                if (answer == "1")
                {
                    progression = menuOne(progression);
                }
                else if (answer == "2")
                {
                    progression = menuTwo(progression);
                }
                else if (answer == "3")
                {
                    progression = menuThree(progression);
                }
                else if (answer == "4")
                {
                    exit = true;
                    System.Console.WriteLine("Goodbye");
                }
                else { System.Console.WriteLine(inputError); }
            }

        }

        public static Progression menuOne (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            bool back = false;
            string answer;
            while (back == false)
            {
                System.Console.WriteLine("\nWhat would you like to do?" +
                                         "\n1) Change the key" +
                                         "\n2) Change the mode" +
                                         "\n3) Change the tuning" +
                                         "\n4) Back to main menu");
                answer = System.Console.ReadLine();
                if (answer == "1") { progression = changeKey(progression); }
                else if (answer == "2") { progression = changeMode(progression); }
                else if (answer == "3") { progression = changeTuning(progression); }
                else if (answer == "4") { back = true; }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression menuTwo(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            bool back = false;
            string answer;
            while (back == false)
            {
                if (progression.getSize() == 0)
                { System.Console.WriteLine("\nThere are no chords in your progression"); }
                else
                {
                    System.Console.WriteLine("\nThe current chords in your progression are: \n" + progression.getChordNames());
                }
                System.Console.WriteLine("\nWhat would you like to do?" +
                                         "\n1) Add a chord" +
                                         "\n2) Replace a chord" +
                                         "\n3) Swap two chords" +
                                         "\n4) Remove a chord" +
                                         "\n5) See more information about a chord" +
                                         "\n6) Add a chord by recomendation" +
                                         "\n7) Back to main menu");
                answer = System.Console.ReadLine();
                if (answer == "1") { progression = addChord(progression); }
                else if (answer == "2") { progression = replaceChord(progression); }
                else if (answer == "3") { progression = swapChords(progression); }
                else if (answer == "4") { progression = removeChord(progression); }
                else if (answer == "5") { examineChords(progression); }
                else if (answer == "6") { progression = addRecomendedChord(progression); }
                else if (answer == "7") { back = true; }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression menuThree (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            bool back = false;
            string answer;
            while (back == false)
            {
                if (progression.getSize() == 0)
                { System.Console.WriteLine("\nThere are no chords in your progression"); }
                else
                {
                    System.Console.WriteLine("\nThe current tablature is:");
                    System.Console.WriteLine("  " + progression.getChordNames());
                    string spacing;
                    int spacingSize;
                    string stringOne = "";
                    string stringTwo = "";
                    string stringThree = "";
                    string stringFour = "";
                    string stringFive = "";
                    string stringSix = "";
                    int i, j;
                    // i = chord, j = string
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        spacingSize = progression.getChord(i - 1).getName().ToCharArray().Count();
                        spacing = "";
                        for (j = 0; j < spacingSize; j++) { spacing = spacing + " "; }
                        stringOne = stringOne + " " + progression.getTabNumber(i, 1) + spacing;
                        stringTwo = stringTwo + " " + progression.getTabNumber(i, 2) + spacing;
                        stringThree = stringThree + " " + progression.getTabNumber(i, 3) + spacing;
                        stringFour = stringFour + " " + progression.getTabNumber(i, 4) + spacing;
                        stringFive = stringFive + " " + progression.getTabNumber(i, 5) + spacing;
                        stringSix = stringSix + " " + progression.getTabNumber(i, 6) + spacing;
                    }
                    System.Console.WriteLine("T" + stringOne);
                    System.Console.WriteLine("T" + stringTwo);
                    System.Console.WriteLine("A" + stringThree);
                    System.Console.WriteLine("A" + stringFour);
                    System.Console.WriteLine("B" + stringFive);
                    System.Console.WriteLine("B" + stringSix);
                }
                System.Console.WriteLine("\nWhat would you like to do?" +
                                         "\n1) Swap two chords" +
                                         "\n2) Increase the pitch of a chord" +
                                         "\n3) Decrease the pitch of a chord" +
                                         "\n4) Back to main menu");

                answer = System.Console.ReadLine();
                if (answer == "1") { progression = swapChords(progression); }
                else if (answer == "2") { progression = increasePitch(progression); }
                else if (answer == "3") { progression = decreasePitch(progression); }
                else if (answer == "4") { back = true; }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression changeKey (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            bool result = false;
            while (result == false)
            {
                System.Console.WriteLine("\nPlease enter the new key. Use '#' (number sign) " +
               "\nfor sharp and 'b' (lowercase b) for flat");
                string newKey = System.Console.ReadLine();
                result = NoteController.checkNoteName(newKey);
                if (result)
                {
                    progression.changeKey(NoteFactory.getNoteByName(newKey));
                    System.Console.WriteLine("\nKey has been changed to " + newKey);
                }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression changeMode (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            bool result = false;
            string answer;
            while (result == false)
            {
                System.Console.WriteLine("\nWhat would you like the  new mode to be?" +
               "\n1) Lydian" +
               "\n2) Ionian" +
               "\n3) Mixolydian" +
               "\n4) Dorian" +
               "\n5) Aeolian" +
               "\n6) Phrygian" +
               "\n7) Locrian");
                answer = System.Console.ReadLine();
                if (answer == "1")
                {
                    progression.changeMode("Lydian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "2")
                {
                    progression.changeMode("Ionian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "3")
                {
                    progression.changeMode("Mixolydian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "4")
                {
                    progression.changeMode("Dorian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "5")
                {
                    progression.changeMode("Aeolian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "6")
                {
                    progression.changeMode("Phrygian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else if (answer == "7")
                {
                    progression.changeMode("Locrian");
                    result = true;
                    System.Console.WriteLine("\nThe mode has been changed to " + progression.getMode().getName());
                }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression changeTuning (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            List<Note> newTuning = new List<Note>();
            for (int i = 6; i > 0; i--)
            {
                string newTuningNote;
                bool result = false;
                while (result == false)
                {
                    System.Console.WriteLine("Please enter the note for string " + i);
                    newTuningNote = System.Console.ReadLine();
                    result = NoteController.checkNoteName(newTuningNote);
                    if (result)
                    {
                        newTuning.Add(NoteFactory.getNoteByName(newTuningNote));
                    }
                    else { System.Console.WriteLine(inputError); }
                }
            }
            progression.changeTuning(newTuning.ElementAt(0), newTuning.ElementAt(1), newTuning.ElementAt(2),
                newTuning.ElementAt(3), newTuning.ElementAt(4), newTuning.ElementAt(5));
            return progression;
        }

        public static Progression addChord(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            string newChordName;
            bool result = false;
            while (result == false)
            {
                System.Console.WriteLine("\nWhat chord would you like to add?");
                newChordName = System.Console.ReadLine();
                if (ChordController.checkChordName(newChordName))
                {
                    result = true;
                    progression.addChord(ChordFactory.getChordByName(newChordName));
                    System.Console.WriteLine("\n" + progression.getChord(progression.getSize() - 1).getName() + " has been added to the progression.");
                }
                else { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static Progression replaceChord(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            string choice;
            bool validChordPositionChoice;
            bool validChordNameChoice;
            string newChordName;

            if (progression.getSize() == 0)
            {
                System.Console.WriteLine("\nThere are no chords in your progression.");
            }
            else
            {
                validChordPositionChoice = false;
                while (validChordPositionChoice == false)
                {
                    int i;
                    System.Console.WriteLine("\nWhat chord would you to replace?");
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                    }
                    choice = System.Console.ReadLine();
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        if (choice == i.ToString())
                        {
                            string oldChordName = progression.getChord(i - 1).getName();
                            validChordPositionChoice = true;
                            validChordNameChoice = false;
                            while (validChordNameChoice == false)
                            {
                                System.Console.WriteLine("\nWhat chord would you like to replace " + progression.getChord(i - 1).getName() + " with?");
                                newChordName = System.Console.ReadLine();
                                if (ChordController.checkChordName(newChordName))
                                {
                                    validChordNameChoice = true;
                                    progression.replaceChord(i - 1, ChordFactory.getChordByName(newChordName));
                                    System.Console.WriteLine("\n" + oldChordName + " has been replaced with " + newChordName);
                                }
                                else { System.Console.WriteLine(inputError); }
                            }
                        }
                    }
                    if (validChordPositionChoice == false) { System.Console.WriteLine(inputError); }
                }
            }
            return progression;
        }

        public static Progression swapChords(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            string choice;
            bool validChordPositionChoiceOne = false;
            bool validChordPositionChoiceTwo = false;

            if (progression.getSize() == 0)
            {
                System.Console.WriteLine("\nThere are no chords in your progression.");
            }
            else
            {
                while (validChordPositionChoiceOne == false)
                {
                    int i;
                    int j;
                    System.Console.WriteLine("\nWhat chord would you like to swap?");
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                    }
                    choice = System.Console.ReadLine();
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        if (choice == i.ToString())
                        {
                            validChordPositionChoiceOne = true;
                            while (validChordPositionChoiceTwo == false)
                            {
                                System.Console.WriteLine("\nWhat chord would you like to swap " + progression.getChord(i - 1).getName() + " with?");
                                choice = System.Console.ReadLine();
                                for (j = 1; j <= progression.getSize(); j++)
                                {
                                    if (choice == j.ToString())
                                    {
                                        validChordPositionChoiceTwo = true;
                                        progression.swapChords(i - 1, j - 1);
                                        System.Console.WriteLine(progression.getChord(i - 1).getName() + " has been swapped with " + progression.getChord(j - 1).getName());
                                    }
                                }
                                if (validChordPositionChoiceTwo == false) { System.Console.WriteLine(inputError); }
                            }
                        }
                    }
                    if (validChordPositionChoiceOne == false) { System.Console.WriteLine(inputError); }
                }
            }
            return progression;
        }

        public static Progression removeChord(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            string choice;
            bool validChoice = false;
            while (validChoice == false)
            {
                int i;
                System.Console.WriteLine("\nWhat chord would you like to remove?");
                for (i = 1; i <= progression.getSize(); i++)
                {
                    System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                }
                choice = System.Console.ReadLine();
                for (i = 1; i <= progression.getSize(); i++)
                {
                    if (choice == i.ToString())
                    {
                        validChoice = true;
                        string oldChordName = progression.getChord(i - 1).getName();
                        progression.removeChord(i - 1);
                        System.Console.WriteLine("\n" + oldChordName + " has been removed;");
                    }
                }
                if (validChoice == false) { System.Console.WriteLine(inputError); }
            }
            return progression;
        }

        public static void examineChords(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            string choice;
            bool validChoice = false;
            while (validChoice == false)
            {
                int i;
                System.Console.WriteLine("\nWhat chord would you like to examine?");
                for (i = 1; i <= progression.getSize(); i++)
                {
                    System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                }
                choice = System.Console.ReadLine();
                for (i = 1; i <= progression.getSize(); i++)
                {
                    if (choice == i.ToString())
                    {
                        validChoice = true;
                        System.Console.WriteLine("\nThe notes in " + progression.getChord(i - 1).getName() +
                            " are " + progression.getChord(i - 1).getNotes());
                        /*
                        System.Console.WriteLine(progression.getChord(i - 1).getName() + " has the intervals " +
                            progression.getDegree());
                        System.Console.WriteLine(progression.getChord(i - 1).getName() + " is the degree " +
                            progression.getChord(i - 1).getIntervals() + " from the key " + progression.getKey().getName());
                            */
                    }
                }
                if (validChoice == false) { System.Console.WriteLine(inputError); }
            }
        }

        public static Progression addRecomendedChord(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            int i;
            string choice;
            bool validChoice = false;
            Note degree = NoteFactory.getNoteByValue(progression.getKey().getValue(), progression.getKey());
            List<Chord> recomendations = new List<Chord>();
            if (progression.getSize() == 0)
            {
                recomendations = ChordFactory.getChordRecomendationsTriads(progression.getKey(), progression.getMode());
                while (validChoice == false)
                {
                    for (i = 0; i < recomendations.Count(); i++)
                    {
                        System.Console.WriteLine((i + 1).ToString() + ") " + recomendations.ElementAt(i).getName());
                        if (i + 1 == recomendations.Count()) { System.Console.WriteLine((i + 2).ToString() + ") See more recomendations"); }
                    }
                    System.Console.WriteLine((i + 2).ToString() + ") Back to chord menu");
                    choice = System.Console.ReadLine();

                    for (i = 1; i <= recomendations.Count(); i++)
                    {
                        if (i.ToString() == choice)
                        {
                            validChoice = true;
                            progression.addChord(recomendations.ElementAt(i - 1));
                            System.Console.WriteLine("\n" + progression.getChord(progression.getSize() - 1).getName() + " has been added to the progression.");
                        }
                    }
                    if ((i).ToString() == choice)
                    {
                        validChoice = true;
                        progression = moreRecomendations(progression);
                    }
                    else if ((i + 1).ToString() == choice)
                    {
                        validChoice = true;
                    }
                    if (validChoice == false) { System.Console.WriteLine(inputError); }
                }
            }
            else
            {
                recomendations = ChordFactory.getChordRecomendationsByLast(progression.getKey(), progression.getChord(progression.getSize() - 1), progression.getMode());
                while (validChoice == false)
                {
                    for (i = 0; i < recomendations.Count(); i++)
                    {
                        System.Console.WriteLine((i + 1).ToString() + ") " + recomendations.ElementAt(i).getName());
                        if (i + 1 == recomendations.Count()) { System.Console.WriteLine((i + 2).ToString() + ") See more recomendations"); }
                    }
                    System.Console.WriteLine((i + 2).ToString() + ") Back to chord menu");
                    choice = System.Console.ReadLine();

                    for (i = 1; i <= recomendations.Count(); i++)
                    {
                        if (i.ToString() == choice)
                        {
                            validChoice = true;
                            progression.addChord(recomendations.ElementAt(i - 1));
                            System.Console.WriteLine("\n" + progression.getChord(progression.getSize() - 1).getName() + " has been added to the progression.");
                        }
                    }
                    if ((i).ToString() == choice)
                    {
                        validChoice = true;
                        progression = moreRecomendations(progression);
                    }
                    else if ((i + 1).ToString() == choice)
                    {
                        validChoice = true;
                    }
                    if (validChoice == false) { System.Console.WriteLine(inputError); }
                }
            }
            return progression;
        }

        public static Progression moreRecomendations(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";

            List<Chord> recomendations = new List<Chord>();
            Note tonic = NoteFactory.getNoteByValue(progression.getKey().getValue(), progression.getKey());
            bool validChoice = false;
            string choice;
            int i;
            while (validChoice == false)
            {
                i = 1;
                System.Console.WriteLine("1) I (" + progression.getMode().getNote(0, progression.getKey()).getName() + ")");
                if (progression.getMode().containsInterval(1))
                {
                    System.Console.WriteLine((i + 1) + ") bII (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(2))
                {
                    System.Console.WriteLine((i + 1) + ") II (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(3))
                {
                    System.Console.WriteLine(((i + 1) + 1) + ") bIII (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(4))
                {
                    System.Console.WriteLine((i + 1) + ") III (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(5))
                {
                    System.Console.WriteLine((i + 1) + ") IV (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(6))
                {
                    System.Console.WriteLine((i + 1) + ") bV (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(7))
                {
                    System.Console.WriteLine((i + 1) + ") V (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(8))
                {
                    System.Console.WriteLine((i + 1) + ") bVI (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(9))
                {
                    System.Console.WriteLine((i + 1) + ") VI (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(10))
                {
                    System.Console.WriteLine((i + 1) + ") bVII (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                if (progression.getMode().containsInterval(11))
                {
                    System.Console.WriteLine((i + 1) + ") VII (" + progression.getMode().getNote(i, progression.getKey()).getName() + ")");
                    i++;
                }
                choice = System.Console.ReadLine();
                for (i = 1; i <= progression.getMode().getSize(); i++)
                {
                    if (i.ToString() == choice)
                    {
                        validChoice = true;
                        tonic = progression.getMode().getNote(i - 1, progression.getKey());
                    }
                }
                if (validChoice == false) { System.Console.WriteLine(inputError); }
            }
            validChoice = false;
            recomendations = ChordFactory.getChordRecomendationsByTonic(progression.getKey(), tonic, progression.getMode());
            while (validChoice == false)
            {
                for (i = 0; i < recomendations.Count(); i++)
                {
                    System.Console.WriteLine((i + 1).ToString() + ") " + recomendations.ElementAt(i).getName());
                    if (i + 1 == recomendations.Count()) { System.Console.WriteLine((i + 2).ToString() + ") Back to chord menu"); }
                }
                choice = System.Console.ReadLine();

                for (i = 1; i <= recomendations.Count(); i++)
                {
                    if (i.ToString() == choice)
                    {
                        validChoice = true;
                        progression.addChord(recomendations.ElementAt(i - 1));
                        System.Console.WriteLine("\n" + progression.getChord(progression.getSize() - 1).getName() + " has been added to the progression.");
                    }
                    else if ((i + 1).ToString() == choice)
                    {
                        validChoice = true;
                    }
                }
                if (validChoice == false) { System.Console.WriteLine(inputError); }
            }
            return progression;
        }
        
        public static Progression increasePitch(Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            if (progression.getSize() == 0)
            {
                System.Console.WriteLine("\nThere are no chords in your progression.");
            }
            else
            {
                bool validChoice = false;
                string choice;
                int i;
                while (validChoice == false)
                {
                    System.Console.WriteLine("\nWhat chord would you like raise?");
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                    }
                    choice = System.Console.ReadLine();
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        if (choice == i.ToString())
                        {
                            validChoice = true;
                            if (TabController.checkPitchRange(progression.getTabPitch(i) + 1, progression.getChord(i - 1).getNoteAt(0), progression.getGuitar()))
                            {
                                progression.changeTabPitch(i, progression.getTabPitch(i) + 1);
                                System.Console.WriteLine("\n" + progression.getChord(i - 1).getName() + " has been raised");
                            }
                            else { System.Console.WriteLine("\nThis chord cannot be raised any further"); }
                        }
                    }
                    if (validChoice == false) { System.Console.WriteLine(inputError); }
                }
            }
            return progression;
        }

        public static Progression decreasePitch (Progression progression)
        {
            string inputError = "\nI'm sorry that was not a valid coice." +
                               "\nPlease try again.";
            if (progression.getSize() == 0)
            {
                System.Console.WriteLine("\nThere are no chords in your progression.");
            }
            else
            {
                bool validChoice = false;
                string choice;
                int i;
                while (validChoice == false)
                {
                    System.Console.WriteLine("\nWhat chord would you like lower?");
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        System.Console.WriteLine(i + ") " + progression.getChord(i - 1).getName());
                    }
                    choice = System.Console.ReadLine();
                    for (i = 1; i <= progression.getSize(); i++)
                    {
                        if (choice == i.ToString())
                        {
                            validChoice = true;
                            if (TabController.checkPitchRange(progression.getTabPitch(i) - 1, progression.getChord(i - 1).getNoteAt(0), progression.getGuitar()))
                            {
                                progression.changeTabPitch(i, progression.getTabPitch(i) - 1);
                                System.Console.WriteLine("\n" + progression.getChord(i - 1).getName() + " has been lowered");
                            }
                            else { System.Console.WriteLine("\nThis chord cannot be lowered any further"); }
                        }
                    }
                    if (validChoice == false) { System.Console.WriteLine(inputError); }
                }
            }
            return progression;
        }
    }
}
