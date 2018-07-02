#/bin/bash
clear
echo "vyberte tridu kterou chcete vypsat nebo napiste all pro vypsani vsech studentu a jejich trid"
cat /root/data/tridy
read class
clear
if [ "$class" = "all" ]
then
while read trida; do
	while read jmeno; do

		echo -e "$trida <---------------> $jmeno"

	done </root/data/$trida

done </root/data/tridy
else
if grep -Fxq "$class" /root/data/tridy
then
clear
while read jmeno; do

		echo -e "$class <---------------> $jmeno"

	done </root/data/$class

else
    echo "Trida $class neexistuje!!"
fi
fi
read -n 1
