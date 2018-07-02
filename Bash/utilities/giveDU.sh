#!/bin/bash
clear

DATE=`date +%Y-%m-%d`
locationName="DU-$USER-${DATE}.txt"

echo -e "Vyberte tridu nebo tridy, ktere chcete zadat domaci ukol z nasledujiciho seznamu:"
echo -e "pokud vyberete vice trid oddelujte je mezerou"
cat /root/data/tridy

read classes
arr=($classes)

for class in ${arr[@]}
do
  if grep -Fxq "$class" /root/data/tridy
then

nano /root/ukoly/$locationName

	while read jmeno; do

	cp /root/ukoly/$locationName /home/$class/$jmeno/Domaci_ukoly

	done </root/data/$class

echo "Ukol $locationName uspesne zadan tride $class" && read -n 1

else
    echo "trida $class neexistuje !!" && read -n 1
fi
done


