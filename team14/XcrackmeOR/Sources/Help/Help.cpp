#include <iostream>
#include <conio.h>
using namespace std;


string your4t()
{
    int h3x3[21];
    for (int i = 0; i < 21; i++)
    {
        if (i == 14) h3x3[i] = 0x6c; // l
        if (i == 1) h3x3[i] = 0x30; //0
        if (i == 18) h3x3[i] = 0x74; // t
        if (i == 3) h3x3[i] = 0x34; //4
        if (i == 19) h3x3[i] = 0x31; // 1
        if (i == 7) h3x3[i] = 0x33; //3
        if (i == 5) h3x3[i] = 0x5f; //_
        if (i == 2) h3x3[i] = 0x6d; //m
        if (i == 20) h3x3[i] = 0x75; // u
        if (i == 8) h3x3[i] = 0x6e; //n
        if (i == 4) h3x3[i] = 0x79; //y
        if (i == 9) h3x3[i] = 0x59; // Y
        if (i == 11) h3x3[i] = 0x5f; // _
        if (i == 0) h3x3[i] = 0x6c; //l
        if (i == 12) h3x3[i] = 0x70; // p
        if (i == 16) h3x3[i] = 0x30; // 0
        if (i == 6) h3x3[i] = 0x4d; //M
        if (i == 15) h3x3[i] = 0x6e; // n
        if (i == 10) h3x3[i] = 0x34; // 4
        if (i == 13) h3x3[i] = 0x30; // 0
        if (i == 17) h3x3[i] = 0x73; // s
    }
    string k3 = "";
    for (int i = 0; i < 21; i++) {
        k3 += char(h3x3[i]);
    }
    return k3;
}

string k3g3n(string b4s3)
{
    string gazprom = "";
    for (int i = 0; i < b4s3.size(); i++) {
        if (b4s3[i] != 'u') {
            gazprom += char(int(b4s3[i] ^ 0b1010101));
        }
        else {
            gazprom += '@';
        }
    }
    return gazprom;
}

bool n4m3v4l1d(string xss1337)
{
    for (int i = 0; i < xss1337.size(); i++)
    {
        if (int(xss1337[i] < 97 || xss1337[i] > 122))
        {
            return false;
        }
    }
    return true;
}

int main()
{
    cout << "1 c0u1d n0t f1nd key f0r f1ag, maybe you can do it?\n";
    cout << "Insert your name (only small latin letters)\n";
    string n4m3;
    cin >> n4m3;
    if (!n4m3v4l1d(n4m3))
    {
        cout << "You failed to even write your name... \n";
        std::cout << "Press any key to exit . . ." << std::endl;
        _getch();
        return 0;
    }
    string k33 = k3g3n(n4m3);
    cout << "Insert your key\n";
    string userKey;
    cin >> userKey;
    if (userKey == k33) {
        cout << "Congrats! Flag is: " + your4t() + "\n";
    }
    else {
        cout << "Wrong! Better luck next time \n";
    }
    std::cout << "Press any key to exit . . ." << std::endl;
    _getch();
}
