using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class ChordController
    {
        private ChordController() { }
        public static bool checkChordName(string name)
        {
            var chordNameFull = name.ToCharArray();
            char[] chordNameNoLetter;
            char[] chordNameSuffix;
            string tonicName = "";

            if(chordNameFull.Count() < 1) { return false; }

            if(chordNameFull[0] == 'A' || chordNameFull[0] == 'B' || chordNameFull[0] == 'C' || chordNameFull[0] == 'D' ||
                chordNameFull[0] == 'E' || chordNameFull[0] == 'F' || chordNameFull[0] == 'G')
            {
                tonicName = chordNameFull[0].ToString();
                chordNameNoLetter = new char[chordNameFull.Count() - 1];
                for (int i = 0; i < chordNameFull.Count() - 1; i++) { chordNameNoLetter[i] = chordNameFull[i + 1]; }
            }
            else { return false; }

            if (chordNameNoLetter.Count() == 0) { return true; }
            else if (chordNameNoLetter[0] == '#' || chordNameNoLetter[0] == 'b')
            {
                tonicName = tonicName + chordNameNoLetter[0].ToString();
                chordNameSuffix = new char[chordNameNoLetter.Count() - 1];
                for (int i = 0; i < chordNameNoLetter.Count() - 1; i++)
                { chordNameSuffix[i] = chordNameNoLetter[i + 1]; }
            }
            else { chordNameSuffix = chordNameNoLetter; }

            if (NoteController.checkNoteName(tonicName) == false) { return false; }

            if (chordNameSuffix.Count() == 0) { return true; }
            
            // X5
            if (chordNameSuffix.Length == 1 && chordNameSuffix[0] == '5')
            {
                return true;
            }
            // X(b5)
            else if (chordNameSuffix.Length == 4 && chordNameSuffix[0] == '(' && chordNameSuffix[1] == 'b' && chordNameSuffix[2] == '5' && chordNameSuffix[3] == ')')
            {
                return true;
            }
            // X(b5)
            else if (chordNameSuffix.Length == 5 && chordNameSuffix[0] == '9' && chordNameSuffix[1] == '(' && chordNameSuffix[2] == 'b' && chordNameSuffix[3] == '5' && chordNameSuffix[4] == ')')
            {
                return true;
            }
            // Xsus
            else if (chordNameSuffix.Length == 3 && chordNameSuffix[0] == 's' && chordNameSuffix[1] == 'u' && chordNameSuffix[2] == 's')
            {
                return true;
            }
            // Xsus2
            else if (chordNameSuffix.Length == 4 && chordNameSuffix[0] == 's' && chordNameSuffix[1] == 'u' && chordNameSuffix[2] == 's' && chordNameSuffix[3] == '2')
            {
                return true;
            }
            // X7sus
            else if (chordNameSuffix.Length == 4 && chordNameSuffix[0] == '7' && chordNameSuffix[1] == 's' && chordNameSuffix[2] == 'u' && chordNameSuffix[3] == 's')
            {
                return true;
            }
            // Xm7
            else if (chordNameSuffix.Length == 2 && chordNameSuffix[0] == 'm' && chordNameSuffix[1] == '7')
            {
                return true;
            }
            // Xdim
            else if (chordNameSuffix.Length == 3 && chordNameSuffix[0] == 'd' && chordNameSuffix[1] == 'i' && chordNameSuffix[2] == 'm')
            {
                return true;
            }
            // Xaug
            else if (chordNameSuffix.Length == 3 && chordNameSuffix[0] == 'a' && chordNameSuffix[1] == 'u' && chordNameSuffix[2] == 'g')
            {
                return true;
            }
            // X(add9)
            else if (chordNameSuffix.Length == 6 && chordNameSuffix[0] == '(' && chordNameSuffix[1] == 'a' && chordNameSuffix[2] == 'd' &&
                chordNameSuffix[3] == 'd' && chordNameSuffix[4] == '9' && chordNameSuffix[5] == ')')
            {
                return true;
            }
            // X7, X7(b9), X7(#9), X7+, X7+(b9)
            else if (chordNameSuffix.Length >= 1 && chordNameSuffix[0] == '7')
            {
                if (chordNameSuffix.Length == 1)
                {
                    return true;
                }
                else if (chordNameSuffix[1] == '+')
                {
                    if(chordNameSuffix.Length == 2)
                    {
                        return true;
                    }
                    else if (chordNameSuffix.Length == 6 && chordNameSuffix[2] == '(' && chordNameSuffix[3] == 'b' && chordNameSuffix[4] == '9' && chordNameSuffix[5] == ')')
                    {
                        return true;
                    }
                    else { return false; }
                }
                else if (chordNameSuffix.Length == 5 && chordNameSuffix[1] == '(' && (chordNameSuffix[2] == 'b' || chordNameSuffix[2] == '#') &&
                     chordNameSuffix[3] == '9' && chordNameSuffix[4] == ')')
                {
                    if (chordNameSuffix.Length == 5 && chordNameSuffix[1] == '(' && chordNameSuffix[2] == '#' &&
                    chordNameSuffix[3] == '9' && chordNameSuffix[4] == ')')
                    {
                        return true;
                    }
                    else if (chordNameSuffix.Length == 5 && chordNameSuffix[1] == '(' && chordNameSuffix[2] == 'b' &&
                    chordNameSuffix[3] == '9' && chordNameSuffix[4] == ')')
                    {
                        return true;
                    }
                    else { return false; }
                }
                else if (chordNameSuffix.Length == 5 && chordNameSuffix[1] == '(' && chordNameSuffix[2] == 'b' &&
                    chordNameSuffix[3] == '5' && chordNameSuffix[4] == ')')
                {
                    return true;
                }
                else { return false; }
            }
            // Xmaj7, Xmaj9, Xmaj7(b5)
            else if (chordNameSuffix.Length >= 4 && chordNameSuffix[0] == 'm' && chordNameSuffix[1] == 'a' && chordNameSuffix[2] == 'j')
            {
                if (chordNameSuffix.Length == 4 && chordNameSuffix[3] == '7') { return true; }
                else if (chordNameSuffix.Length == 4 && chordNameSuffix[3] == '9') { return true; }
                else if (chordNameSuffix.Length == 8 && chordNameSuffix[3] == '7' && chordNameSuffix[4] == '(' && chordNameSuffix[5] == 'b' && chordNameSuffix[6] == '5' && chordNameSuffix[7] == ')')
                { return true; }
                else { return false; }
            }
            // Xm(maj7)
            else if (chordNameSuffix.Length == 7 && chordNameSuffix[0] == 'm' && chordNameSuffix[1] == '(' && chordNameSuffix[2] == 'm' &&
                chordNameSuffix[3] == 'a' && chordNameSuffix[4] == 'j' && chordNameSuffix[5] == '7' && chordNameSuffix[6] == ')')
            {
                return true;
            }
            // X9+ X9(#11)
            else if (chordNameSuffix.Length >= 2 && chordNameSuffix[0] == '9')
            {
                if (chordNameSuffix.Length == 2 && chordNameSuffix[1] == '+')
                {
                    return true;
                }
                else if (chordNameSuffix.Length == 6 && chordNameSuffix[1] == '(' && chordNameSuffix[2] == '#' && chordNameSuffix[3] == '1'
                    && chordNameSuffix[4] == '1' && chordNameSuffix[5] == ')')
                {
                    return true;
                }
                else { return false; }
            }
            // Xm9(maj7)
            else if (chordNameSuffix.Length == 8 && chordNameSuffix[0] == 'm' && chordNameSuffix[1] == '9' && chordNameSuffix[2] == '(' &&
                chordNameSuffix[3] == 'm' && chordNameSuffix[4] == 'a' && chordNameSuffix[5] == 'j' && chordNameSuffix[6] == '7' && chordNameSuffix[7] == ')')
            {
                return true;
            }
            // X11
            else if (chordNameSuffix.Length == 2 && chordNameSuffix[0] == '1' && chordNameSuffix[1] == '1')
            {
                return true;
            }
            // Xm11
            else if (chordNameSuffix.Length == 3 && chordNameSuffix[0] == 'm' && chordNameSuffix[1] == '1' && chordNameSuffix[2] == '1')
            {
                return true;
            }
            // XM11
            else if (chordNameSuffix.Length == 3 && chordNameSuffix[0] == 'M' && chordNameSuffix[1] == '1' && chordNameSuffix[2] == '1')
            {
                return true;
            }
            // X13
            else if (chordNameSuffix.Length == 2 && chordNameSuffix[0] == '1' && chordNameSuffix[1] == '3')
            {
                return true;
            }
            // X13(b9)
            else if (chordNameSuffix.Length == 6 && chordNameSuffix[0] == '1' && chordNameSuffix[1] == '3' && chordNameSuffix[2] == '('
                && chordNameSuffix[3] == 'b' && chordNameSuffix[4] == '9' && chordNameSuffix[5] == ')')
            {
                return true;
            }
            // X13(#9)
            else if (chordNameSuffix.Length == 6 && chordNameSuffix[0] == '1' && chordNameSuffix[1] == '3' && chordNameSuffix[2] == '('
                && chordNameSuffix[3] == '#' && chordNameSuffix[4] == '9' && chordNameSuffix[5] == ')')
            {
                return true;
            }
            // X13(b9b5)
            else if (chordNameSuffix.Length == 8 && chordNameSuffix[0] == '1' && chordNameSuffix[1] == '3' && chordNameSuffix[2] == '(' &&
                chordNameSuffix[3] == 'b' && chordNameSuffix[4] == '9' && chordNameSuffix[5] == 'b' && chordNameSuffix[6] == '5' && chordNameSuffix[7] == ')')
            {
                return true;
            }

            // minor and major overlap
            else if (chordNameSuffix.Length >= 1)
            {
                char[] newChordNameSuffix;
                if (chordNameSuffix[0] == 'm')
                {
                    newChordNameSuffix = new char[chordNameSuffix.Length - 1];
                    for (int i = 0; i < chordNameSuffix.Length - 1; i++) { newChordNameSuffix[i] = chordNameSuffix[i + 1]; }
                }
                else
                {
                    newChordNameSuffix = chordNameSuffix;
                }
                // Xm
                if (newChordNameSuffix.Length == 0)
                {
                    return true;
                }
                // X9
                else if (newChordNameSuffix.Length == 1 && newChordNameSuffix[0] == '9')
                {
                    return true;
                }
                // X6
                else if (newChordNameSuffix.Length >= 1 && newChordNameSuffix[0] == '6')
                {
                    if (newChordNameSuffix.Length == 1) { return true; }
                    else if (newChordNameSuffix.Length == 3 && newChordNameSuffix[1] == '/' && newChordNameSuffix[2] == '9')
                    { return true; }
                    else { return false; }
                }
                // X7, X7(b5)
                else if (newChordNameSuffix.Length >= 1 && newChordNameSuffix[0] == '7')
                {
                    if (newChordNameSuffix.Length == 1) { return true; }
                    else if (newChordNameSuffix.Length == 5 && newChordNameSuffix[1] == '(' && newChordNameSuffix[2] == 'b' && newChordNameSuffix[3] == '5' && newChordNameSuffix[4] == ')')
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }

        }
    }
}
