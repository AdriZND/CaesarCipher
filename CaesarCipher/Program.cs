using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pedimos el mensaje que queremos convertir y lo convertimos en un array de carácteres para iterarlo
            Console.WriteLine("Que mensaje quieres encriptar?");
            string message = Console.ReadLine().ToLower();
            char[] secretMessage = message.ToCharArray();

            //Llamamos al método que encripta el mensaje y lo imprimimos por consola ya encriptado.
            Console.WriteLine("El mensaje encriptado es " + String.Join("", Encrypt(secretMessage, 3)));

            Console.WriteLine("El mensaje desencriptado es " + String.Join("", Decrypt(Encrypt(secretMessage, 3), 3)));
        }

        //Metodo de encriptado del mensaje
        static char[] Encrypt(char[] secretMessage, int key)
        {
            //Array con las letras del alfabeto 
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            char[] encryptedMessage = new char[secretMessage.Length];
            //Bucle que encuentra en el array de Alfabeto el indice de cada letra del mensaje y la convierte en la letra deseada del alfabeto saltando tantos lugares en el mismo como se indique en la key.
            for (int i = 0; i < secretMessage.Length; i++)
            {
                //If para controlar que solo los caracteres del abecedario sean tenidos en cuenta y encriptados, saltandonos los demás.
                if (!Char.IsLetter(secretMessage[i]))
                {
                    continue;
                }
                char letter = secretMessage[i];
                int letterSwap = (Array.IndexOf(alphabet, letter) + key) % alphabet.Length;
                char newLetter = alphabet[letterSwap];
                encryptedMessage[i] = newLetter;


            }
            return encryptedMessage;
        }
        //Método para desencriptar el mensaje, funciona igual que el de encriptado pero revertimos el array con las letras del alfabeto para que el resultado sea el que queremos.
        static char[] Decrypt(char[] encryptedMessage, int key)
        {

            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Array.Reverse(alphabet);

            char[] decryptedMessage = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (!Char.IsLetter(encryptedMessage[i]))
                {
                    continue;
                }
                char letter = encryptedMessage[i];
                int letterSwap = (Array.IndexOf(alphabet, letter) + key) % alphabet.Length;
                char newLetter = alphabet[letterSwap];
                decryptedMessage[i] = newLetter;

            }
            return decryptedMessage;
        }
    }
}
