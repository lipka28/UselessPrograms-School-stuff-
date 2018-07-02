#!/bin/bash
clear
echo -e "Oprava zacala!"

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

echo -e "V systemu byli nalezeni tito uzvatele: "

while read trida2; do
	while read jmeno; do

		echo -e "$trida2 $jmeno"

	done </root/data/$trida2

done </root/data/tridy

read -n 1
