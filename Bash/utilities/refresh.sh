#!/bin/bash
clear

echo -e "Vyberte tridu, kterou chcete vyprazdnit z nasledujiciho seznamu:"
cat /root/data/tridy

read class

if grep -Fxq "$class" /root/data/tridy
then

	while read jmeno; do

	userdel -r $jmeno

	done </root/data/$class

rm -r /home/$class
mkdir /home/$class

rm -r /root/data/
mkdir /root/data/

ls /home/ >> /root/data/tridyTMP

while read class; do

	if [[ "$class" != "aquota.user" ]]
	then
		if [[ "$class" == "lost+found" ]]
		then
			continue
		else
			echo $class >> /root/data/tridy
		fi
	fi

done </root/data/tridyTMP

rm /root/data/tridyTMP

while read trida; do

	ls /home/$trida >> /root/data/$trida

done </root/data/tridy

echo -e "Trida byla uspesne vyprazdnena " && read -n 1

else
    echo "trida neexistuje !!" && read -n 1 && exit
fi
