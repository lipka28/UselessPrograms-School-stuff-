#!/bin/bash
clear

echo -e "Prosim vyberte tridu do ktere chcete pridat uzivatele z tohoto seznamu:"
cat /root/data/tridy

read class

if grep -Fxq "$class" /root/data/tridy
then

echo -n "Vlozte jmeno noveho uzivatele(pouze mala pismena a cisla): "
read jmeno
echo "ROOT pravomoce ? [a/N]: "
read priv

if [[ $priv == "a" ]]; then
	echo -n "Vlozte heslo pro noveho ROOT uzivatele: "
	read -s heslo
	useradd -ou 0 -g 0 -d /root -s /bin/bash $jmeno
	echo $jmeno:$heslo | chpasswd
else	
	adduser --disabled-login --gecos "" "$jmeno" && echo $jmeno:"heslo" | chpasswd && passwd -e $jmeno && echo $jmeno >> /root/data/$class && usermod -m -d /home/$class/$jmeno $jmeno && chmod -R 700 /home/$class/$jmeno && echo "Uzivatel $jmeno uspesne vytvoren!" && read -n 1 && exit || echo -e "Nekde se stala chyba!" read -n 1 && exit
	
	
	
fi

else
echo -e "Vami zvolena trida neexistuje!!" && read -n 1 && exit
fi


