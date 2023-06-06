FROM php:apache

RUN docker-php-ext-install mysqli

RUN apt-get update && apt-get install -y \
    libjpeg-dev \
    libpng-dev \
    libfreetype6-dev

RUN docker-php-ext-configure gd --with-freetype --with-jpeg \
    && docker-php-ext-install -j$(nproc) gd

COPY .htaccess /etc/apache2/

WORKDIR /var/www/html

COPY . /var/www/html/

RUN a2enmod rewrite

EXPOSE 80