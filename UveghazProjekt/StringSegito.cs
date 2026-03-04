using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UveghazProjekt
{
    internal class StringSegito
    {
        public static string Osszefuz(string first, string second, string joiner)
        {
            string[] linesFirst = first.Split('\n');
            string[] linesSecond = second.Split('\n');

            int maxLength = Math.Max(linesFirst.Length, linesSecond.Length);

            string combined = "";

            for (int i = 0; i < maxLength; i++)
            {
                if (i > 0) combined += '\n';
                if (i < linesFirst.Length) combined += linesFirst[i];
                if (i < linesSecond.Length) combined += joiner + linesSecond[i];
            }

            return combined;
        }

        public static string Betol(string content, int indentSize)
        {
            string output = "";
            string indent = new string(' ', indentSize);
            string[] lines = content.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    output += '\n';
                }

                if (lines[i] != "")
                {
                    output += indent + lines[i];
                }
            }

            return output;
        }

        public static int IgazHossz(string text)
        {
            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\x1B')
                {
                    for (; i < text.Length && text[i] != 'm'; i++)
                    {
                    }
                }
                else
                {
                    length++;
                }
            }

            return length;
        }

        public static string KozepreIgazit(int length, string content)
        {
            return KozepreIgazit(length, content, true);
        }

        public static string KozepreIgazit(int length, string content, bool addRight)
        {
            int contentLength = IgazHossz(content);
            if (contentLength > length)
            {
                return content;
            }

            string right = new string(' ', (length - contentLength) / 2);
            string output = new string(' ', length - right.Length - contentLength) + content;

            if (addRight)
            {
                output += right;
            }

            return output;
        }

        public static string JobbraKiegeszit(int length, string content)
        {
            int contentLength = IgazHossz(content);

            if (contentLength > length)
            {
                return content;
            }

            return content + new string(' ', length - contentLength);
        }

        public static string BalraKiegeszit(int length, string content)
        {
            int contentLength = IgazHossz(content);

            if (contentLength > length)
            {
                return content;
            }

            return new string(' ', length - contentLength) + content;
        }

        public static string KozepreIgazitTobbsor(int length, string content)
        {
            string output = "";
            string[] lines = content.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    output += '\n';
                }

                output += KozepreIgazit(length, lines[i]);
            }

            return output;
        }

        public static string StringEgyenloHossz(string first)
        {
            (string padded, _) = StringekEgyenloHossz(first, first);

            return padded;
        }

        public static (string, string) StringekEgyenloHossz(string first, string second)
        {
            string[] linesFirst = first.Split('\n');
            string[] linesSecond = second.Split('\n');

            int maxLength = Math.Max(linesFirst.Length, linesSecond.Length);
            int maxWidth = 0;

            for (int i = 0; i < maxLength; i++)
            {
                if (i < linesFirst.Length) maxWidth = Math.Max(maxWidth, StringSegito.IgazHossz(linesFirst[i]));
                if (i < linesSecond.Length) maxWidth = Math.Max(maxWidth, StringSegito.IgazHossz(linesSecond[i]));
            }

            string stringFirst = "";
            string stringSecond = "";

            for (int i = 0; i < maxLength; i++)
            {
                if (i > 0 && i < linesFirst.Length) stringFirst += '\n';
                if (i > 0 && i < linesSecond.Length) stringSecond += '\n';

                if (i < linesFirst.Length) stringFirst += StringSegito.JobbraKiegeszit(maxWidth, linesFirst[i]);
                if (i < linesSecond.Length) stringSecond += StringSegito.JobbraKiegeszit(maxWidth, linesSecond[i]);
            }

            return (stringFirst, stringSecond);
        }
    }
}