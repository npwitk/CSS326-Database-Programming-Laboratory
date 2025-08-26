#!/bin/bash
# Start MySQL service and launch phpMyAdmin

brew services start mysql
cd /opt/homebrew/share/phpmyadmin || exit
php -S localhost:8080

