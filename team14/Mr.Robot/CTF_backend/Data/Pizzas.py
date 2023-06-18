Pizzas = [
    {"name": 'Маргарита', "description": 'Вечная классика',
     "price": 420, "weight": 750,
     "pic": "https://static.1000.menu/img/content-v2/ef/27/10853/picca-margarita-v-domashnix"
            "-usloviyax_1608783820_4_max.jpg"},

    {"name": 'Пепперони', "description": 'Классические колбаски и томатный соус с сыром',
     "price": 380, "weight": 800,
     "pic": "https://robfood.ru/wp-content/uploads/2016/01/pepperoni_1300x1300.jpg"},

    {"name": 'Острая', "description": 'Острая версия пепперони с халапеньо',
     "price": 420, "weight": 800,
     "pic": "https://www.crushpixel.com/big-static7/preview4/pizza-pepperoni-with-chili-jalapeno-142651.jpg"},

    {"name": 'Неополитанская', "description": 'Мать всех пицц',
     "price": 400, "weight": 600,
     "pic": "https://www.alma.scuolacucina.it/wp-content/uploads/2021/11/PIZZA-NAPOLETANA-3-web-624x416"
            ".jpg"},

    {"name": 'Сицилийская', "description": 'Пицца напоминает фокаччу – высокая, обильно приправленная специальным '
                                           'томатным соусом, подсушенным на солнце',
     "price": 420, "weight": 850,
     "pic": "https://www.alma.scuolacucina.it/wp-content/uploads/2021/11/shutterstock_1698744682-624x468.jpg"},

    {"name": 'Пицца-гурме', "description": 'Пицца для настоящих гурманов',
     "price": 600, "weight": 700,
     "pic": "https://www.alma.scuolacucina.it/wp-content/uploads/2021/11/CSCI44-BOSCO-scaled-e1638802251995.jpg"}
]


def get_pizzas():
    return Pizzas


def add_pizzas(element):
    Pizzas.append(element)
    return Pizzas
