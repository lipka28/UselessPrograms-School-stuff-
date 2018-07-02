#!/bin/bash
clear
while read trida; do
	while read jmeno; do

		echo -e "$trida $jmeno"

	done </root/data/$trida

done </root/data/tridy

echo -e "Zadejte uzivatele ktereho chcete smazat (ve fomratu Trida Jmeno):"
read class user

if grep -Fxq "$class" /root/data/tridy && grep -Fxq "$user" /root/data/$class
then

userdel -r -f "$user"
	while read name; do

		if [[ "$name" != "$user" ]]
		then
			echo $name >> /root/data/tmp
		fi

	done </root/data/$class
rm /root/data/$class
cp /root/data/tmp /root/data/$class
rm /root/data/tmp

echo "Uzivatel $user byl uspesne smazan ze tridy $class" && read -n 1

else
    echo "Uzivatel neni ve tride kterou jste zvolili !" && read -n 1 && exit
fi
