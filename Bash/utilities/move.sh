#/bin/bash
echo "vyberte tridu ze ktere chcete presunout studenty a tridu do ktere chcete presunout tridu (POZOR!!! vsichni studenti v cilove tride, pokud tam nejaci jsou budou smazani):"
cat /root/data/tridy
read trida1 trida2

if grep -Fxq "$trida1" /root/data/tridy
then
if grep -Fxq "$trida2" /root/data/tridy
then

	while read jmeno; do

	userdel -r $jmeno

	done </root/data/$trida2
fi
rm -r /home/$trida2
mv /home/$trida1 /home/$trida2	
mkdir /home/$trida1

else
clear
echo "zdrojova trida neexistuje!!" && read -n 1 && exit
fi

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

echo "studenti uspesne presunuti ze tridy $trida1 do tridy $trida2"
read -n 1
