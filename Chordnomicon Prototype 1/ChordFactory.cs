using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class ChordFactory
    {
        public static Chord getChordByName(string name)
        {
            if (!(ChordController.checkChordName(name)))
            { throw new System.ArgumentException("Parameter must have a valid name", "Chord Name: " + name); }

            int i = 0;
            bool needsMore = true;
            string tonicName;
            Note tonic;
            Chord chord = new Chord();
            chord.setName(name);
            var chordName = name.ToCharArray();
            
            tonicName = chordName[i].ToString();
            i++;

            if (i + 1 <= chordName.Length && (chordName[i] == 'b' || chordName[i] == '#'))
            {
                tonicName = tonicName + chordName[i].ToString(); 
                i++;
            }

            tonic = NoteFactory.getNoteByName(tonicName);
            chord.addNote(tonic);

            // Calculate first interval (dim3, m3, M3, aug3)
            if (needsMore)
            {
                // X5
                if (i + 1 <= chordName.Length && chordName[i] == '5')
                {
                    chord.addNote(calculateNote(7, tonic));
                    i++;
                    needsMore = false;
                }
                // Xsus
                else if (i + 3 <= chordName.Length && chordName[i] == 's' && chordName[i + 1] == 'u' && chordName[i + 2] == 's')
                {
                    i = i + 3;
                    if (i + 1 <= chordName.Length && chordName[i] == '2')
                    {
                        chord.addNote(calculateNote(2, tonic));
                        i++;
                    }
                    else { chord.addNote(calculateNote(5, tonic)); }
                    chord.addNote(calculateNote(7, tonic));
                    needsMore = false;
                }
                // X7sus
                else if (i + 4 <= chordName.Length && chordName[i] == '7' && chordName[i + 1] == 's' && chordName[i + 2] == 'u' && chordName[i + 3] == 's')
                {
                    chord.addNote(calculateNote(5, tonic));
                    chord.addNote(calculateNote(7, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    i = i + 4;
                    needsMore = false;
                }
                // Xdim
                else if (i + 3 <= chordName.Length && chordName[i] == 'd' && chordName[i + 1] == 'i' && chordName[i + 2] == 'm')
                {
                    chord.addNote(calculateNote(3, tonic));
                    chord.addNote(calculateNote(6, tonic));
                    i = i + 3;
                    needsMore = false;
                }
                //Xm
                else if (i + 1 == chordName.Length && chordName[i] == 'm')
                {
                    chord.addNote(calculateNote(3, tonic));
                    i++;
                }
                // Xm...
                else if (i + 1 <= chordName.Length && chordName[i] == 'm' && chordName[i + 1] != 'a')
                {
                    chord.addNote(calculateNote(3, tonic));
                    i++;
                }
                // X...
                else
                {
                    chord.addNote(calculateNote(4, tonic));
                }
            }

            // Add next interval (dim5, P5, aug5)

            if (needsMore)
            {
                // X(b5)
                if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'b' && chordName[i + 2] == '5' 
                    && chordName[i + 3] == ')')
                {
                    chord.addNote(calculateNote(6, tonic));
                    i = i + 4;
                    needsMore = false;
                }
                // X7(b5)
                else if (i + 5 <= chordName.Length && chordName[i] == '7' && chordName[i + 1] == '(' && chordName[i + 2] == 'b'
                    && chordName[i + 3] == '5' && chordName[i + 4] == ')')
                {
                    chord.addNote(calculateNote(6, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    i = i + 5;
                    needsMore = false;
                }
                // Xmaj7(b5)
                else if (i + 8 <= chordName.Length && chordName[i] == 'm' && chordName[i + 1] == 'a' && chordName[i + 2] == 'j'
                    && chordName[i + 3] == '7' && chordName[i + 4] == '(' && chordName[i + 5] == 'b' && chordName[i + 6] == '5')
                {
                    chord.addNote(calculateNote(6, tonic));
                    chord.addNote(calculateNote(11, tonic));
                    i = i + 8;
                    needsMore = false;
                }
                // X9(b5)
                else if (i + 5 <= chordName.Length && chordName[i] == '9' && chordName[i + 1] == '(' && chordName[i + 2] == 'b'
                    && chordName[i + 3] == '5')
                {
                    chord.addNote(calculateNote(6, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    chord.addNote(calculateNote(2, tonic));
                    i = i + 5;
                    needsMore = false;
                }
                // X13(b9b5)
                else if (i + 8 <= chordName.Length && chordName[i] == '1' && chordName[i + 1] == '3' && chordName[i + 2] == '('
                    && chordName[i + 3] == 'b' && chordName[i + 4] == '9' && chordName[i + 5] == 'b' && chordName[i + 6] == '5')
                {
                    chord.addNote(calculateNote(6, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    chord.addNote(calculateNote(1, tonic));
                    chord.addNote(calculateNote(9, tonic));
                    i = i + 8;
                    needsMore = false;
                }
                // Xaug
                else if (i + 3 <= chordName.Length && chordName[i] == 'a' && chordName[i + 1] == 'u' && chordName[i + 2] == 'g')
                {
                    chord.addNote(calculateNote(8, tonic));
                    i = i + 3;
                    needsMore = false;
                }
                // X7+
                else if (i + 2 <= chordName.Length && chordName[i] == '7' && chordName[i + 1] == '+')
                {
                    chord.addNote(calculateNote(8, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    i = i + 2;
                    // X7+(b9)
                    if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'b' && chordName[i + 2] == '9')
                    {
                        chord.addNote(calculateNote(1, tonic));
                        i = i + 4;
                    }
                    needsMore = false;
                }
                // X9+
                else if (i + 2 <= chordName.Length && chordName[i] == '9' && chordName[i + 1] == '+')
                {
                    chord.addNote(calculateNote(8, tonic));
                    chord.addNote(calculateNote(10, tonic));
                    chord.addNote(calculateNote(2, tonic));
                    i = i + 2;
                    needsMore = false;
                }
                // X...
                else { chord.addNote(calculateNote(7, tonic)); }
            }

            // Add final intervals (M6, m7, M7)

            if (needsMore)
            {
                // X(add9)
                if (i + 6 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'a' && chordName[i + 2] == 'd'
                    && chordName[i + 3] == 'd' && chordName[i + 4] == '9')
                {
                    chord.addNote(calculateNote(2, tonic));
                    i = i + 6;
                    needsMore = false;
                }
                // X6
                else if (i + 1 <= chordName.Length && chordName[i] == '6')
                {
                    chord.addNote(calculateNote(9, tonic));
                    i++;
                    // X6/9
                    if (i + 2 <= chordName.Length && chordName[i] == '/' && chordName[i + 1] == '9')
                    {
                        chord.addNote(calculateNote(2, tonic));
                        i = i + 2;
                    }
                    needsMore = false;
                }
                // X13
                else if (i + 2 <= chordName.Length && chordName[i] == '1' && chordName[i + 1] == '3')
                {
                    chord.addNote(calculateNote(10, tonic));
                    i = i + 2;
                    // X13(b9)
                    if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'b' && chordName[i + 2] == '9')
                    {
                        chord.addNote(calculateNote(1, tonic)); 
                        i = i + 4;
                    }
                    // X13(#9)
                    else if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == '#' && chordName[i + 2] == '9')
                    {
                        chord.addNote(calculateNote(3, tonic));
                        i = i + 4;
                    }
                    else { chord.addNote(calculateNote(2, tonic)); }
                    chord.addNote(calculateNote(9, tonic));
                    needsMore = false;
                }
                // X7
                else if (i + 1 <= chordName.Length && chordName[i] == '7')
                {
                    chord.addNote(calculateNote(10, tonic));
                    i++;
                    // X7(b9)
                    if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'b' && chordName[i + 2] == '9')
                    {
                        chord.addNote(calculateNote(1, tonic));
                        i = i + 4;
                    }
                    // X7(#9)
                    else if (i + 4 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == '#' && chordName[i + 2] == '9')
                    {
                        chord.addNote(calculateNote(3, tonic));
                        i = i + 4;
                    }
                    needsMore = false;
                }
                // X9
                else if (i + 1 <= chordName.Length && chordName[i] == '9')
                {
                    i++;
                    // X9(#11)
                    if (i + 5 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == '#' && chordName[i + 2] == '1'
                        && chordName[i + 3] == '1')
                    {
                        chord.addNote(calculateNote(10, tonic));
                        chord.addNote(calculateNote(2, tonic));
                        chord.addNote(calculateNote(6, tonic));
                        i = i + 5;
                    }
                    // X9maj7
                    else if (i + 6 <= chordName.Length && chordName[i + 1] == 'm' && chordName[i + 2] == 'a'
                    && chordName[i + 3] == 'j' && chordName[i + 4] == '7')
                    {
                        chord.addNote(calculateNote(11, tonic));
                        chord.addNote(calculateNote(2, tonic));
                        i = i + 6;
                        needsMore = false;
                    }
                    else
                    {
                        chord.addNote(calculateNote(10, tonic));
                        chord.addNote(calculateNote(2, tonic));
                    }
                    needsMore = false;
                }
                // X11
                else if (i + 1 <= chordName.Length && chordName[i] == '1' && chordName[i + 1] == '1')
                {
                    chord.addNote(calculateNote(10, tonic));
                    chord.addNote(calculateNote(2, tonic));
                    chord.addNote(calculateNote(5, tonic));
                    i = i + 2;
                    needsMore = false;
                }
                // XM11
                else if (i + 3 <= chordName.Length && chordName[i] == 'M' && chordName[i + 1] == '1' && chordName[i + 2] == '1')
                {
                    chord.addNote(calculateNote(11, tonic));
                    chord.addNote(calculateNote(2, tonic));
                    chord.addNote(calculateNote(5, tonic));
                    i = i + 3;
                    needsMore = false;
                }
                // Xmaj7
                else if (i + 3 <= chordName.Length && chordName[i] == 'm' && chordName[i + 1] == 'a' && chordName[i + 2] == 'j')
                {
                    chord.addNote(calculateNote(11, tonic));
                    i = i + 3;
                    if (i + 1 <= chordName.Length && chordName[i] == '9')
                    {
                        chord.addNote(calculateNote(2, tonic));
                    }
                    i++;
                    needsMore = false;
                }
                // X(maj7)
                else if (i + 6 <= chordName.Length && chordName[i] == '(' && chordName[i + 1] == 'm' && chordName[i + 2] == 'a' && chordName[i + 3] == 'j' 
                    && chordName[i + 4] == '7')
                {
                    chord.addNote(calculateNote(11, tonic));
                    i = i + 6;
                    needsMore = false;
                }
            }

            // X/bassNote
            if (i < chordName.Count() && chordName[i] == '/')
                {
                    i++;
                    tonicName = chordName[i].ToString();
                    i++;
                    if (i < chordName.Count())
                    {
                        if (chordName[i] == 'b' || chordName[i] == '#')
                        {
                            tonicName = tonicName + chordName[i].ToString();
                            i++;
                        }
                }
                tonic = NoteFactory.getNoteByName(tonicName);
                chord.insertNote(tonic, 0);
            }
            if (i < chordName.Length)
            { throw new System.ArgumentException("\nThe character length for " + name + " is: " + chordName.Length + "\nThe index for " + name + " is: " + i, "Chord Name: " + name); }

            return chord;
        }

        public static List<Chord> getChordRecomendationsTriads(Note key, Mode mode)
        {
            int i;
            int tonicValueCheck;
            Note tonic;
            List<Chord> chords = new List<Chord>();
            for (i = 0; i < 12; i++)
            {
                tonicValueCheck = key.getValue() + i;
                if (tonicValueCheck > 12) { tonicValueCheck = tonicValueCheck - 12; }
                tonic = NoteFactory.getNoteByValue(tonicValueCheck, key);

                if (mode.containsInterval(i))
                {
                    // augmented 0 4 8
                    if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
                        && (mode.containsInterval(8 + i) || (mode.containsInterval((8 + i) - 12))))
                    { chords.Add(ChordFactory.getChordByName(tonic.getName() + "aug")); }

                    // major 0 4 7 
                    if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12))) 
                        && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
                    { chords.Add(ChordFactory.getChordByName(tonic.getName())); }

                    // minor 0 3 7
                    if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
                        && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
                    { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m")); }
                    
                    // diminished 0 3 6
                    if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
                        && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12))))
                    { chords.Add(ChordFactory.getChordByName(tonic.getName() + "dim")); }

                }
            }
            return chords;
        }

        public static List<Chord> getChordRecomendationsByTonic(Note key, Note tonic, Mode mode)
        {
            int i = tonic.getValue() - key.getValue();
            if (i < 0) { i = i + 12; }
            List<Chord> chords = new List<Chord>();
            
            // Triads and five diad
            // "X" major 0 4 7 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName())); }

            // "Xm" minor 0 3 7
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m")); }

            // "Xdim" diminished 0 3 6
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "dim")); }

            // "Xaug" augmented 0 4 8
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(8 + i) || (mode.containsInterval((8 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "aug")); }

            // "X(b5)" flat five 0 4 6
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "(b5)")); }

            // "X5" five diad 0 7
            if ((mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "5")); }

            // "Xsus" suspended 0 5 7
            if ((mode.containsInterval(5 + i) || (mode.containsInterval((5 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "sus")); }

            // suspended two 0 2 7
            if ((mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "sus2")); }

            // Sevens
            // "X7" seven 0 4 7 10
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7")); }

            // "Xm7" minor seven 0 3 7 10
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m7")); }

            // "X7sus" suspended seven 0 5 7 10
            if ((mode.containsInterval(5 + i) || (mode.containsInterval((5 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7sus")); }

            // "X7(b5)" suspended seven 0 4 6 10
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7(b5)")); }

            // "Xm7(b5)" suspended seven 0 3 6 10
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m7(b5)")); }

            // "Xmaj7" major seven 0 4 7 11
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "maj7")); }
            
            // "Xm(maj7)" minor with major seven 0 3 7 11
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m(maj7)")); }

            // "Xmaj7(b5)" major seven flat five 0 4 6 11
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "maj7(b5)")); }

            // "X7+" augmented seven 0 4 8 10
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(8 + i) || (mode.containsInterval((8 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7+")); }

            // "X7+(b9)" augmented seven 0 4 8 10 1
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(8 + i) || (mode.containsInterval((8 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(1 + i) || (mode.containsInterval((1 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7+(b9)")); }

            // Sixes
            // "X6" seven 0 4 7 9 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "6")); }

            // "X6/9" seven 0 4 7 9 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "6/9")); }

            // "Xm6" seven 0 3 7 9
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m6")); }

            // "Xm6/9" seven 0 3 7 9 2
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m6/9")); }

            // Nines
            // "X(add9)" add nine 0 4 7 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "(add9)")); }
            
            // "X9" nine 0 4 7 10 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "9")); }

            // "Xmaj9" major nine 0 4 7 11 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "maj9")); }

            // "Xm9(maj7)" minor nine with major seven 0 3 7 11 2
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m9(maj7)")); }

            // "X7(b9)" seven flat nine 0 4 7 10 1
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((1 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7(b9)")); }

            // "X7(#9)" major seven flat five 0 4 7 10 3
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "7(#9)")); }

            // "X9(#11)" nine with sharp eleven 0 4 7 10 2 6
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "9(#11)")); }

            // "X9+" augmented nine 0 4 8 10 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(8 + i) || (mode.containsInterval((8 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "9+")); }

            // "X9(b5)" nine flat five 0 4 6 10 2
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "9(b5)")); }

            // Elevens
            // "X11" eleven 0 4 7 10 2 5 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(5 + i) || (mode.containsInterval((5 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "11")); }

            // "Xm11" minor eleven 0 3 7 10 2 5 
            if ((mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(5 + i) || (mode.containsInterval((5 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "m11")); }

            // "XM11" major eleven 0 4 7 10 2 5 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(11 + i) || (mode.containsInterval((11 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(5 + i) || (mode.containsInterval((5 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "M11")); }

            // Thirteens
            // "X13" thirteen 0 4 7 10 2 9 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(2 + i) || (mode.containsInterval((2 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "13")); }

            // "X13(b9)" thirteen flat nine 0 4 7 10 1 9 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(1 + i) || (mode.containsInterval((1 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "13(b9)")); }

            // "X13(#9)" thirteen sharp nine 0 4 7 10 3 9 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(7 + i) || (mode.containsInterval((7 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(3 + i) || (mode.containsInterval((3 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "13(#9)")); }

            // "X13(b9b5)" thirteen 0 4 6 10 1 9 
            if ((mode.containsInterval(4 + i) || (mode.containsInterval((4 + i) - 12)))
            && (mode.containsInterval(6 + i) || (mode.containsInterval((6 + i) - 12)))
            && (mode.containsInterval(10 + i) || (mode.containsInterval((10 + i) - 12)))
            && (mode.containsInterval(1 + i) || (mode.containsInterval((1 + i) - 12)))
            && (mode.containsInterval(9 + i) || (mode.containsInterval((9 + i) - 12))))
            { chords.Add(ChordFactory.getChordByName(tonic.getName() + "13(b9b5)")); }

            return chords;
        }

        public static List<Chord> getChordRecomendationsByLast (Note key, Chord lastChord, Mode mode)
        {
            List<Chord> chords = new List<Chord>();
            List<Chord> fives = new List<Chord>();
            List<Chord> sevens = new List<Chord>();
            List<Chord> sixes = new List<Chord>();
            int value;
            int distance;
            Note note;
            bool foundDegree;
            bool foundFifth = false;
            bool foundSeventh = false;
            bool foundSixth = false;

            // V -> I -> IV
            foundDegree = false;
            distance = lastChord.getNoteAt(0).getValue() - key.getValue();
            if (distance < 12) { distance = distance + 12; }
            if (mode.containsInterval(7 + distance) || mode.containsInterval(7 + distance - 12))
            {
                value = lastChord.getNoteAt(0).getValue() + 7;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            // May add b5 and #5 recomendations back in
            /* 
            else if (mode.containsInterval(6))
            {
                value = lastChord.getNoteAt(0).getValue() + 6;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            else if (mode.containsInterval(8))
            {
                value = lastChord.getNoteAt(0).getValue() + 8;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            */
            else { note = NoteFactory.getNoteByValue(key.getValue(), key); }
            if (foundDegree)
            {
                fives = ChordFactory.getChordRecomendationsByTonic(key, note, mode);
                foundFifth = true;
            }

            // VII -> I -> II
            foundDegree = false;
            distance = lastChord.getNoteAt(0).getValue() - key.getValue();
            if (distance < 12) { distance = distance + 12; }
            if (mode.containsInterval(10 + distance) || mode.containsInterval(10 + distance - 12))
            {
                value = lastChord.getNoteAt(0).getValue() + 10;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            else if (mode.containsInterval(11 + distance) || mode.containsInterval(11 + distance - 12))
            {
                value = lastChord.getNoteAt(0).getValue() + 11;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            else { note = NoteFactory.getNoteByValue(key.getValue(), key); }
            if (foundDegree)
            {
                sevens = ChordFactory.getChordRecomendationsByTonic(key, note, mode);
                foundSeventh = true;
            }


            // VI -> I -> III
            foundDegree = false;
            distance = lastChord.getNoteAt(0).getValue() - key.getValue();
            if (distance < 12) { distance = distance + 12; }
            if (mode.containsInterval(9 + distance) || mode.containsInterval(9 + distance - 12))
            {
                value = lastChord.getNoteAt(0).getValue() + 9;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            else if (mode.containsInterval(8 + distance) || mode.containsInterval(8 + distance - 12))
            {
                value = lastChord.getNoteAt(0).getValue() + 8;
                if (value > 12) { value = value - 12; }
                note = NoteFactory.getNoteByValue(value, key);
                foundDegree = true;
            }
            else { note = NoteFactory.getNoteByValue(key.getValue(), key); }
            if (foundDegree)
            {
                sixes = ChordFactory.getChordRecomendationsByTonic(key, note, mode);
                foundSixth = true;
            }

            if (foundFifth) { chords.AddRange(fives); }
            if (foundSeventh) { chords.AddRange(sevens); }
            if (foundSixth) { chords.AddRange(sixes); }

            return chords;
        }

        private static Note calculateNote(int distance, Note _key)
        {
            int next = _key.getValue() + distance;
            if (next > 12) { next = next - 12; }
            return (NoteFactory.getNoteByValue(next, _key));
        }
    }
}
