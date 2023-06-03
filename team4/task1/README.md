# g0SUSlug1 (Easy)
# Legend
## RU
Ваш австралийский товарищ отправил вам инструкцию по входу в госуслуги, но вы заметили, что картинка весит больше чем должна...
 
## EN
Your Australian friend sent you instructions for entering gosuslugi services, but you noticed that the picture weighs more than it should...

# Description
The picture's height has been changed in header, but the data remains

# Solution
- Change pictures's 16th bit to 0xC2 and 17th to 0x01  (it doesn't have to be exactly 0x01C2, it can be any value that big enough to password became visible, 0x1C2 is just original height)
- Observe the flag in the password field 

# Flags
HITS{acropalypse-light-version}

# Handout
screenshot.bmp
