Rolls = [
    {"name": 'Томаго Суши Ролл',
     "description": 'Сыр филадельфия, огурцы, индейка холодного копчения, японский омлет и икра летучей рыбы тобико',
     "price": 420, "weight": 300,
     "pic": "https://www.bakenroll.az/ru/image/tamaqo-min.jpg"},

    {"name": 'Куриный Суши Ролл с Чеддером', "description": 'Обжаренная курица, рис, огурцы и соус барбекю',
     "price": 320, "weight": 320,
     "pic": "https://www.bakenroll.az/ru/image/800x800/qomen-roll-1500x950.jpg"},

    {"name": 'Таки Суши Ролл',
     "description": 'Сыр филадельфия, копченая форели, авакадо, икры тобико, риса, нори и огурцов',
     "price": 450, "weight": 400,
     "pic": "https://www.bakenroll.az/ru/image/taki-roll.jpg"},

    {"name": 'Чукка Суши Ролл',
     "description": 'Семга холодного копчения, огурцы, крем сыр, водоросли чукка и ореховый соус',
     "price": 410, "weight": 380,
     "pic": "https://www.bakenroll.az/ru/image/cuka-roll-retush.jpg"},

    {"name": 'Суши Ролл Калифорния с крабом', "description": 'Икра летучей рыбы тобико, огурцы, рис, японский '
                                                             'майонеза, снежный краб (сурими), водоросли нори',
     "price": 450, "weight": 300,
     "pic": "https://www.bakenroll.az/ru/image/california-crab-roll.jpg"},

    {"name": 'Калифорния Хот Ролл', "description": 'Сурими (крабовые палочки), рис, нори, тобики и панировочные сухари',
     "price": 300, "weight": 300,
     "pic": "https://www.bakenroll.az/ru/image/roll-kaliforniya-khot.jpg"},

    {"name": 'Америка Хот Суши Рол',
     "description": 'рис, индейка холодного копчения, японский омлет, огурцы, перец и панировочные сухари',
     "price": 380, "weight": 360,
     "pic": "https://www.bakenroll.az/ru/image/amerika-hot-roll.jpg"},

    {"name": 'Бонито Суши Ролл',
     "description": 'Высушенная стружка тунца, огурцы, рис, японский майонез, нори и семга в соусе терияки',
     "price": 410, "weight": 420,
     "pic": "https://www.bakenroll.az/ru/image/bonito-roll.jpg"},

    {"name": 'Унаги Маки Суши Ролл', "description": 'Рыба унаги (угорь), рис, водоросли нори и огурцы',
     "price": 330, "weight": 400,
     "pic": "https://www.bakenroll.az/ru/image/maki-with-smoked-eel.jpg"},

    {"name": 'Мидори Хот Суши Рол',
     "description": 'Крем сыр, огурцы, рис, тигровые креветки, нори, панировочные сухари',
     "price": 460, "weight": 400,
     "pic": "https://www.bakenroll.az/ru/image/midori-goryachiy-roll-s-krevetkami.jpg"},
]


def get_rolls():
    return Rolls


def add_rolls(element):
    Rolls.append(element)
    return Rolls
