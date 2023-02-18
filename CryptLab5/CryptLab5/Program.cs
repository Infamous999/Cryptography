using System;

namespace CryptLab5


int[,] sBlock = new int[,]
            {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            };
const int sizeOfBlock = 6;



public static void SblockDecrypt(byte[] byData, FileStream fs, int sizeOfBlock, int reverse, int[,] sBlock)
{
    BitArray biData = new BitArray(byData);
    for (int i = 0; i < biData.Length; i += sizeOfBlock)
    {
        bool Bit1 = biData[i]; // на каждом шаге записываем биты по порядку
        bool Bit2 = biData[i + 1];
        bool Bit3 = biData[i + 2];
        bool Bit4 = biData[i + 3];
        bool Bit5 = biData[i + 4];
        bool Bit6 = biData[i + 5];

        int Row = ChooseRow(Bit1, Bit2); // знаем, что первые два бита - это номер строки
        int Column = 0;

        int num3 = Convert.ToInt32(Bit3); // знаем, что с 3 по 6 бит - это номер стоблца в двоичном коде
        int num4 = Convert.ToInt32(Bit4);
        int num5 = Convert.ToInt32(Bit5);
        int num6 = Convert.ToInt32(Bit6);

        string Bin1 = Convert.ToString(num3); // переводим из битов в двоичный код
        string Bin2 = Convert.ToString(num4);
        string Bin3 = Convert.ToString(num5);
        string Bin4 = Convert.ToString(num6);

        string BinaryFoundNumber = Bin1 + Bin2 + Bin3 + Bin4; // записываем в одну строку двоичный код

        int FoundNumber = Convert.ToInt32(BinaryFoundNumber, 2); // переводим в десятичную систему счисления и находим число которое было записано в биты
        for (int j = 0; j <= 15; j++)
        {
            if (FoundNumber == sBlock[Row, j]) // по значению находим номер стоблца
            {
                Column = j;
            }
        }

        String BinaryColumn = Convert.ToString(Column, 2); // переводим номер строки в двоичный код
        while (BinaryColumn.Length < 4)
        {
            BinaryColumn = "0" + BinaryColumn;
        }

        string cBin1 = Convert.ToString(BinaryColumn[0]);
        string cBin2 = Convert.ToString(BinaryColumn[1]);
        string cBin3 = Convert.ToString(BinaryColumn[2]);
        string cBin4 = Convert.ToString(BinaryColumn[3]); // число переведено в двоичный код

        bool nBit1 = Convert.ToBoolean(Convert.ToInt32(cBin1));
        bool nBit3 = Convert.ToBoolean(Convert.ToInt32(cBin2));
        bool nBit4 = Convert.ToBoolean(Convert.ToInt32(cBin3));
        bool nBit6 = Convert.ToBoolean(Convert.ToInt32(cBin4)); // каждая цифра двоичного кода записана для каждого нового 1, 3, 4 и 6 бита

        biData[i] = nBit1;
        biData[i + 1] = Bit2;
        biData[i + 2] = nBit3;
        biData[i + 3] = nBit4;
        biData[i + 4] = Bit1;
        biData[i + 5] = nBit6;
    }

    byData = ConvertToByte(biData);

    fs.Write(byData, 0, (byData.Length - reverse));
}
