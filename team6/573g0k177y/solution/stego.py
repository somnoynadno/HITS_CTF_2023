from PIL import Image

INPUT = "input.png"
OUTPUT = "output.png"
SQL = "SELECT * FROM users;"

def encode(string):
    return ''.join(bin(ord(char))[2:].zfill(8) for char in string)

def decode(binary_string):
    chunks = [binary_string[i:i+8] for i in range(0, len(binary_string), 8)]
    return ''.join([chr(int(chunk, 2)) for chunk in chunks])

original = Image.open(INPUT)
original = original.convert("RGB")
width, height = original.size

steg = Image.new("RGB", (width, height))
cipher = encode(SQL);

cur = 0
for i in range(width):
    for j in range(height):
        r, g, b = original.getpixel((j,i));
        if cur < len(cipher):
            curBit = cipher[cur]
            cur = cur + 1;
            if curBit == "0":
                b &= 254;
            else:
                b |= 1;
        steg.putpixel((j,i), (r,g,b));

steg.save(OUTPUT)
        
        
