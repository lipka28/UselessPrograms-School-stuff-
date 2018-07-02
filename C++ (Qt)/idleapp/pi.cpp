#include "pi.h"

Pi::Pi(QObject *parent) : QObject(parent)
{
    pi = 0.0;
    base = 4.0;
    var = 1.0;
    sign = 1;
}

double Pi::result()
{
    return pi;
}

void Pi::evaluatePi()
{
    if(sign){

        pi += base/var;
        var += 2;
        sign = 0;

    }
    else{

        pi -= base/var;
        var += 2;
        sign = 1;

    }
}

QString Pi::toQString()
{
    QString data(QString::number(pi,'g',100));
    return data;
}
