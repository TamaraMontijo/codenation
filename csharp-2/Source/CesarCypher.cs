using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            Regex regex = new Regex("^[A-Za-z0-9\\s]*$");

            if (message == "") return "";
            if (message == null) throw new ArgumentNullException();
            if(!regex.IsMatch(message)) throw new ArgumentOutOfRangeException(); // check special char

            char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            string msgString = message.ToLower(); // pass msg to lower case
            char[] msgArray = msgString.ToCharArray(); // pass msg to an array
            char[] encryptedMsg = new char[msgArray.Length]; // create a new array for encripted msg

            for (int i = 0; i < msgArray.Length; i++) // for each iteration
            {
              char letter = msgArray[i]; // message's character to be switched
              int letterPosition = Array.IndexOf(alphabet, letter); // index of correspondent letter in alphabet array (returns -1 if the char is not in the array)
              if ( letterPosition == -1 ) // if the letter to switch is not in alphabet string
              {
                encryptedMsg[i] = letter; // puts the same letter into the array
              }
              else
              {
                int newLetterPosition = (letterPosition + 3) % 26; // index of the new letter
                char letterEncoded = alphabet[newLetterPosition]; // new letter to be used
                encryptedMsg[i] = letterEncoded; // puts the new letter into the array for the encripted msg
              }
            }
            string encodedString = String.Join("", encryptedMsg); // transforms the array into a string
            return encodedString;
          }


        public string Decrypt(string cryptedMessage)
        {
            Regex regex = new Regex("^[A-Za-z0-9\\s]*$");

            if (cryptedMessage == "") return "";
            if (cryptedMessage == null) throw new ArgumentNullException();
            if(!regex.IsMatch(cryptedMessage)) throw new ArgumentOutOfRangeException();

            char[] alphabet = new char[] {'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a'};
            string msgString = cryptedMessage.ToLower();
            char[] msgArray = msgString.ToCharArray();
            char[] encryptedMsg = new char[msgArray.Length];

            for (int i = 0; i < msgArray.Length; i++)
            {
              char letter = msgArray[i];
              int letterPosition = Array.IndexOf(alphabet, letter);
              if ( letterPosition == -1 )
              {
                encryptedMsg[i] = letter;
              }
              else
              {
                int newLetterPosition = (letterPosition - 3) % 26;
                char letterEncoded = alphabet[newLetterPosition];
                encryptedMsg[i] = letterEncoded;
              }
            }
            string encodedString = String.Join("", encryptedMsg);
            return encodedString;
        }
    }
}

