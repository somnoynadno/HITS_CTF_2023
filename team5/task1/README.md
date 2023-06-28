# cybersecurity_task_kt_volkova

## Legend

### RU

Хакерман Петя, убегая от преследования, прокричал "не все так просто как кажется!", передал вам флешку и убежал. Дома на флешке вы обнаружили два файла: `thekey.png` и `=.+.zip` 

Ваша задача - найти флаг и ввести его в формате "HITS{флаг}"

Известно, что thekey.png зашифрован ключом длиной 18 байт с помощью XOR.

### EN

Hacker Petya, escaping from pursuit, yelled out "not everything is as easy as it seems!", gave you the flash drive and ran away. At home you found two files on the flash drive: `thekey.png` and `=.+.zip`. 

Your task is to find the flag and enter it in the format "HITS{flag}"

It is known that thekey.png is encrypted with an 18-byte key using XOR.

## Description

`=.+.zip` is a password-protected archive. `thekey.png` contains a recognisable picture. Archive contains some files which contain a flag. Don't let the sly fox deceive you!

## Solution

1 - Decrypt `thekey.png` 
- get first 18 bytes from any PNG, xor it with encrypted one and you will get the key
- decode `thekey.png` with the found key

2 - Extract files from archive
- Find the video by decoded thumbnail
- Copy the video URL and pass it to a regex from archive name
- Use found match as archive password

3 - Explore the archive 
- open `we_need_to_go_deeper.jpg` by an archiver
- copy the `name_needed.png`
- walk down the fox hole till the bottom
- get a fox picture (`noice.png`) and copy it's filename without the extension
- use the name (`noice`) as the key to XOR the `name_needed.png`

4 - enter the found flag in format: "HITS{flag}"

## Flag
HITS{ThisIsNotAFlag}

## Handout
`thekey.png` and `=.+.zip` 
