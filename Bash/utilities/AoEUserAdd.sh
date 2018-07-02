#!/bin/bash
clear

echo -e "Vitejte v hromadnem pridavani uzivatelu. Prosim vyberte tridu do ktere chcete pridat uzivatele z tohoto seznamu:"
cat /root/data/tridy

read class

if grep -Fxq "$class" /root/data/tridy
then
    echo -e "Nyni budete prezentovani s textovym editorem do ktereho prosim zapiste jmena uctu ktera chcete vytvorit. Zadavejte jedno jmeno na jeden radek(pouze mala pismena a cisla) a po dokonceni stisknete ctrl+o a podtvrtte ulozeni a ctrl + x pro ukonceni zapisu.(stisknete libovolnou klavesu pro pokracovani)" && read -n 1
	
nano /root/data/tmp

while read jmeno; do
  
adduser --disabled-login --gecos "" "$jmeno" && echo $jmeno:"heslo" | chpasswd && passwd -e $jmeno && echo $jmeno >> /root/data/$class && usermod -m -d /home/$class/$jmeno $jmeno && chmod -R 700 /home/$class/$jmeno  || echo -e "Spatne jmeno uzivatel $jmeno nebyl registrovan" >> /root/data/fail

done </root/data/tmp

clear

echo -e "Tito uzivatele nebyli vytvoreni k vuli chybam ve jmene. Prosim pouzivejte jen mala pismena a cisla: "
cat /root/data/fail

echo -e "uzivatele byli pridani upsesne " && read -n 1
rm /root/data/fail
rm /root/data/tmp

else
    echo "trida neexistuje !!" && read -n 1 && exit
fi
