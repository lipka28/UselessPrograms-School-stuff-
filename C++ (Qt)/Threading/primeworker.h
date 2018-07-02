#ifndef PRIMEWORKER_H
#define PRIMEWORKER_H

#include <QObject>
#include <QThread>
#include "globalstates.h"

class PrimeWorker : public QObject
{
    Q_OBJECT
public:
    explicit PrimeWorker(QObject *parent = nullptr);

private:
    void findPrimes(unsigned int from, unsigned int to);

signals:
    void resultReady(unsigned int result);
    void allResultsSent();

public slots:
    void doWork(unsigned int from, unsigned int to);
};

#endif // PRIMEWORKER_H
