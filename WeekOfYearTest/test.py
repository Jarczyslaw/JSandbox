from datetime import date
from datetime import timedelta

startDate = date(2011, 1, 1)
endDate = date(2031, 12, 31)

dayDelta = timedelta(1)

with open('weeks.txt', 'a') as file:
    currentDate = startDate;
    while currentDate <= endDate:
        week = currentDate.isocalendar()[1]
        line = currentDate
        file.write(f'{currentDate:%Y-%m-%d}: {week}\n')
        currentDate = currentDate + dayDelta
