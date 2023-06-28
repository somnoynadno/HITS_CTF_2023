import numpy as np
from PIL import Image

from consts import *
from helper.qrgenerator import QrGenerator
from helper.qrmixer import QrMixer

# Create not encoded qr
QrGenerator.generate(RESULT_FILE_NAME, FLAG_TEXT)

# Get image as array of RGB pixels
image = Image.open(RESULT_FILE_NAME).convert('RGB')
image = np.asarray(image)

# Encode and add noise to our qr image
new_array = QrMixer.mix(KEY_COLORS_COUNT, NOISE_COLORS_COUNT, KEY_COLORS, NOISE_COLORS, image)

# Create encoded qr
new_image = Image.fromarray(new_array)
new_image.save(ENCODED_FILE_NAME)
