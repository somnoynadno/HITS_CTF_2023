FROM php:apache

RUN docker-php-ext-install mysqli

COPY .htaccess /etc/apache2/

WORKDIR /var/www/html

COPY . /var/www/html/

RUN a2enmod rewrite

EXPOSE 80