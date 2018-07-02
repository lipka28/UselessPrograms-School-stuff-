#ifndef PI_H
#define PI_H

#include <QObject>
#include <QString>

class Pi : public QObject
{
    Q_OBJECT
public:
    explicit Pi(QObject *parent = nullptr);
    double result();


private:
    double pi;
    double base;
    double var;
    bool sign;

signals:

public:

    QString toQString();

public slots:
    void evaluatePi();

};

#endif // PI_H
