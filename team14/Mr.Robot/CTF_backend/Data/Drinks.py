Drinks = [
    {"name": 'Coca-Cola', "description": 'Кока-кола в железной банке',
     "price": 100, "volume": 0.375,
     "pic": "https://ogorod-foodmarket.ru/image/cache/catalog/easyphoto/9212/coca-cola-original-0-355-l-zh-b-1"
            "-650x650.jpg"},

    {"name": 'Coca-Cola Zero', "description": 'Кока-кола без сахара в железной банке',
     "price": 100, "volume": 0.375,
     "pic": "https://cdn.shopify.com/s/files/1/0043/9258/3217/products/Coca-Coka-No-Sugar-can_de24556c-f324-4afa-b8d9"
            "-bf9cf7a1b463_2048x.png?v=1620308634"},

    {"name": 'E-ON KIWI BLAST', "description": 'Энергетический напиток со вкусом киви-ананас',
     "price": 150, "volume": 0.450,
     "pic": "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/20/69/80/33/25/65/600001701183b0.jpeg"},

    {"name": 'E-ON BCAA-2000', "description": 'Энергетический напиток для спортсменов с BCAA кислотами',
     "price": 170, "volume": 0.450,
     "pic": "https://main-cdn.sbermegamarket.ru/mid9/hlr-system/314/407/377/281/238/100028049487b0.jpg"},

    {"name": 'Святой источник', "description": 'Вода негазированная ключевая',
     "price": 80, "volume": 0.5,
     "pic": "https://static.detmir.st/media_pim/696/176/3176696/1500/0.jpg?1681408063590"},

    {"name": 'Святой источник', "description": 'Вода негазированная для тех кто очень хочет пить',
     "price": 200, "volume": 10,
     "pic": "https://aqua-life.spb.ru/foto/215420224052020.jpg"}
]


def get_drinks():
    return Drinks


def add_drinks(element):
    Drinks.append(element)
    return Drinks
