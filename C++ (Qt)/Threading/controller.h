#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <QObject>
#include <QThread>
#include "facworker.h"
#include "primeworker.h"

class Controller : public QObject
{
    Q_OBJECT
    QThread facThread;
    QThread primeThread;
public:
    explicit Controller(QObject *parent = nullptr);
    ~Controller();
    FacWorker * factorial;
    PrimeWorker * prime;

signals:
    void startFac(int num);
    void startPrime(unsigned int from, unsigned int to);

public slots:
};

#endif // CONTROLLER_H
