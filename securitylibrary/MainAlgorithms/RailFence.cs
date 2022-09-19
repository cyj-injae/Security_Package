using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            /*ex: plaintext=  meetmeaftertheparty
      ciphertext= mtaehayemfrereettpt
      key=2
      m=m remove e from plaintext
      e!=t remove e from plaintext & key =3 
      m==m && t==t break then returned key =3
*/
            cipherText = cipherText.ToLower();
            int key = 2;
            for (int i = 0; i < plainText.Length / 2; i++)
            {
                if (plainText[i] != cipherText[i])
                {
                    plainText = plainText.Remove(i, 1);
                    key++;
                }
                if (plainText[i] == cipherText[i])
                    plainText = plainText.Remove(i + 1, 1);
                if (plainText[0] == cipherText[0] && plainText[1] == cipherText[1])
                    break;
            }
            return key;
        }

        public string Decrypt(string cipherText, int key)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string plainText, int key)
        {

            string cipherText = "";
            for (int i = 0; i < key; i++)
            {
                for (int j = i; j < plainText.Length; j += key)
                {
                    cipherText += plainText[j];
                }
            }
            return cipherText;
        }
    }
}
    

