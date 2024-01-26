import { format, isSameDay } from 'date-fns';
import React, { useState } from 'react';
import UserCalendarService from '../../services/UserCalendarService';

var dataFromDatabase: UserCalendar = await UserCalendarService.getUserCalendar();

const Calendar = () => {
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);
  const [currentMonth, setCurrentMonth] = useState<number>(new Date().getMonth());

  const handleDateClick = (date: Date) => {
    setSelectedDate(date);
    // 
  };

  const handlePrevClick = () => {
    setCurrentMonth(prevMonth => (prevMonth - 1 + 12) % 12);
  };

  const handleNextClick = () => {
    setCurrentMonth(prevMonth => (prevMonth + 1) % 12);
  };

  const generateDays = () => {
    const daysInMonth = new Date(new Date().getFullYear(), currentMonth + 1, 0).getDate();
    const daysArray = [];
  
    const handleDateClickWrapper = (date: any) => {
      handleDateClick(date);
    };
  
    const renderCell = (dayCounter: any, date: any) => {
      const isToday = isSameDay(date, new Date());
      const isSelected = selectedDate && isSameDay(date, selectedDate);
  
      const classes = `calendar-day ${isToday ? 'today' : ''} ${isSelected ? 'selected' : ''}`;
  
      const formattedDate = format(date, 'yyyy-MM-dd');
      const dayData = dataFromDatabase.workingDays.find(data => format(new Date(data.date), 'yyyy-MM-dd') === formattedDate);
  
      const content = dayCounter <= daysInMonth ? (
        <>
          <div className="date">
            <span>{dayCounter}.</span>
          </div>
          <div className="hours">
            {dayData ? (
              <a href="days">Hours: <span>{dayData.numberOfHours}</span></a>
            ) : (
              <a href="days">No data</a>
            )}
          </div>
        </>
      ) : null;
  
      return (
        <td key={dayCounter} className={classes} onClick={() => handleDateClickWrapper(date)}>
          {content}
        </td>
      );
    };
  
    let dayCounter = 1;
  
    for (let week = 1; week <= 5; week++) {
      daysArray.push(
        <tr key={week}>
          {Array.from({ length: 7 }).map((_, index) => {
            const date = new Date(new Date().getFullYear(), currentMonth, dayCounter);
  
            const cell = renderCell(dayCounter, date);
  
            dayCounter++;
  
            return cell;
          })}
        </tr>
      );
    }
  
    return daysArray;
  };

  const currentMonthName = new Date(new Date().getFullYear(), currentMonth, 1).toLocaleString('en-US', { month: 'long' });

  return (
    <div className="wrapper">
      <section className="content">
        <h2><i className="ico timesheet"></i>TimeSheet</h2>
        <div className="grey-box-wrap">
          <div className="top">
            <a href="#" className="prev" onClick={handlePrevClick}><i className="zmdi zmdi-chevron-left"></i>previous month</a>
            <span className="center">{currentMonthName}, {new Date().getFullYear()}</span>
            <a href="#" className="next" onClick={handleNextClick}>next month<i className="zmdi zmdi-chevron-right"></i></a>
          </div>
          <div className="bottom">
            <table className="month-table">
              <thead>
                <tr className="head">
                  <th><span>monday</span></th>
                  <th>tuesday</th>
                  <th>wednesday</th>
                  <th>thursday</th>
                  <th>friday</th>
                  <th>saturday</th>
                  <th>sunday</th>
                </tr>
                <tr className="mobile-head">
                  <th>mon</th>
                  <th>tue</th>
                  <th>wed</th>
                  <th>thu</th>
                  <th>fri</th>
                  <th>sat</th>
                  <th>sun</th>
                </tr>
              </thead>
              <tbody>{generateDays()}</tbody>
            </table>
          </div>
        </div>
        <div className="total">
          <span>Total hours: <em>{dataFromDatabase.totalHours}</em></span>
        </div>
      </section>
    </div>
  );
};

export default Calendar;
