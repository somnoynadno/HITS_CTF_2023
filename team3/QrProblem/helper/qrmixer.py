from copy import copy
from random import randint

import numpy as np


class QrMixer:
    @staticmethod
    def mix(key_colors_count, noise_colors_count, key_colors, noise_colors, image_pixels):
        black = [0, 0, 0]
        white = [255, 255, 255]
        result = copy(image_pixels)
        for i in range(len(image_pixels)):
            for j in range(len(image_pixels[i])):
                if i < 8 and j < 8 or i + 8 >= len(image_pixels) and j < 8 or i < 8 and j + 8 >= len(image_pixels[i]):
                    # Qr patterns will not be colored
                    continue
                if np.array_equal(image_pixels[i][j], black):
                    result[i][j] = key_colors[randint(0, min(len(key_colors), key_colors_count - 1))]
                elif np.array_equal(image_pixels[i][j], white):
                    result[i][j] = noise_colors[randint(0, min(len(noise_colors), noise_colors_count - 1))]
        return result
