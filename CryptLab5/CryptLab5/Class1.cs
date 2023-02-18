using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CryptLab5

public static void SblockEncrypt(byte[] byData, FileStream fs, int sizeOfBlock, int reverse, int[,] sBlock)
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

        int Row = ChooseRow(Bit5, Bit2); // выбираем строку по битам (5 2 биты)
        int Column = ChooseColumn(Bit1, Bit3, Bit4, Bit6); // выбираем столбец по битам (1 3 4 6 биты)

        int FoundNumber = sBlock[Row, Column]; // число в нужной ячейке
        string BinaryFoundNumber = Convert.ToString(FoundNumber, 2); // переводим его в двоичный код

        while (BinaryFoundNumber.Length < 4)
        {
            BinaryFoundNumber = "0" + BinaryFoundNumber;
        }

        string Bin1 = Convert.ToString(BinaryFoundNumber[0]);
        string Bin2 = Convert.ToString(BinaryFoundNumber[1]);
        string Bin3 = Convert.ToString(BinaryFoundNumber[2]);
        string Bin4 = Convert.ToString(BinaryFoundNumber[3]); // число переведено в двоичный код
        bool nBit3 = Convert.ToBoolean(Convert.ToInt32(Bin1));
        bool nBit4 = Convert.ToBoolean(Convert.ToInt32(Bin2));
        bool nBit5 = Convert.ToBoolean(Convert.ToInt32(Bin3));
        bool nBit6 = Convert.ToBoolean(Convert.ToInt32(Bin4)); // каждая цифра из двоичного кода записана для каждого нового 3, 4, 5 и 6 бита 

        biData[i] = Bit5; // 1 и 2 биты это номер выбранной строки в двоичном коде
        biData[i + 1] = Bit2;
        biData[i + 2] = nBit3; // записываются новые значения битов
        biData[i + 3] = nBit4;
        biData[i + 4] = nBit5;
        biData[i + 5] = nBit6;
    }

    byData = ConvertToByte(biData);

    fs.Write(byData, 0, (byData.Length - reverse));
}

int ChooseColumn(bool bit1, bool bit3, bool bit4, bool bit6)
{
    throw new NotImplementedException();
}

int ChooseRow(bool bit5, bool bit2)
{
    throw new NotImplementedException();
}