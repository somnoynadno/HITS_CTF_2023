import qrcode


class QrGenerator:
    @staticmethod
    def generate(file_name, flag_text):
        qr = qrcode.QRCode(
            version=1,
            error_correction=qrcode.constants.ERROR_CORRECT_L,
            box_size=1,
            border=0,
        )
        qr.add_data(flag_text)
        qr.make(fit=True)

        img = qr.make_image(fill_color="black", back_color="white")

        type(img)

        img.save(file_name)
