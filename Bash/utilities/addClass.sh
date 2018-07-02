#!/bin/bash
clear
echo -n "Vlozte nazev nove tridy: "
read nazev

mkdir /home/$nazev && touch /root/data/$nazev && echo $nazev >> /root/data/tridy && echo -e "Trida uspesne vytvorena!!"

read -n 1



