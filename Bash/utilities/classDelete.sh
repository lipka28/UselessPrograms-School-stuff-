#!/bin/bash
clear

echo -e "Vyberte tridu, kterou chcete smazat z nasledujiciho seznamu:"
cat /root/data/tridy

read class

if grep -Fxq "$class" /root/data/tridy
then

	while read trida; do

		if [[ "$trida" != "$class" ]]
		then
			echo $trida >> /root/data/tmp
		fi

	done </root/data/tridy

rm /root/data/tridy
cp /root/data/tmp /root/data/tridy
rm /root/data/tmp

	while read jmeno; do

	userdel -r $jmeno

	done </root/data/$class

rm /root/data/$class
rm -r /home/$class

echo -e "Trida byla smazana uspesne " && read -n 1

else
    echo "trida neexistuje !!" && read -n 1 && exit
fi
