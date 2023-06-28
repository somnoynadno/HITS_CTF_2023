# Rainbow QR Lol (Medium)

## Legend

### RU

Надеюсь, вы тоже любите цвета и задачи на угадывание

### EN

I hope you also like colors and guessing tasks

## Description

Encrypted QR

## Generator

File ```consts.py``` contains all necessary constants and custom properties

Run ```main.py``` to generate images

FLAG_TEXT - your flag you want to hide  
RESULT_FILE_NAME - file name with **not** hidden QR with your flag  
ENCODED_FILE_NAME - file name with hidden QR with your flag

The problem is to find the flag in HIDDEN QR in generated 'ENCODED_FILE_NAME' file

## Solution

To solve it you should find the key colors that should be colored to BLACK and other to WHITE  
So you will get the right QR that contains your secret flag

## Flag

You can put your custom flag in ```consts.py``` and generate new QR  
Default: **M1niecr4ft моя жизнь**

## Handout

Default: ```encrypted.png```