"use client";

import React, { useState } from 'react';
import { Calendar, dateFnsLocalizer } from 'react-big-calendar';
import { format } from 'date-fns/format';
import parse from 'date-fns/parse';
import startOfWeek from 'date-fns/startOfWeek';
import getDay from 'date-fns/getDay';
import {startOfDay} from 'date-fns/startOfDay';
import {addHours} from 'date-fns/addHours';
import 'react-big-calendar/lib/css/react-big-calendar.css';

const locales = {
  'en-US': require('date-fns/locale/en-US'),
};

const localizer = dateFnsLocalizer({
  format,
  parse,
  startOfWeek,
  getDay,
  locales,
});

type CalendarEvent = {
  start: Date;
  end: Date;
  title: string;
  desc?: string;
};

interface CalendarEventProps {
  event: CalendarEvent;
}

const MyCustomEvent: React.FC<CalendarEventProps> = ({ event }) => {
  return (
    <div className="bg-orange-200 p-2 rounded-md shadow">
      <strong>{event.title}</strong>
      {event.desc && `: ${event.desc}`}
    </div>
  );
};

interface HeaderProps {
  date: Date;
}
const CustomHeader: React.FC<HeaderProps> = ({ date,}) => {
  const dayNumber = format(date, 'd');
  const dayName = format(date, 'eee');

  return (
    <div className="flex flex-col items-center justify-center">
      <span className="font-bold">{dayNumber}</span>
      <span>{dayName}</span>
    </div>
  );
};

const MyWeekCalendar: React.FC = () => {
  const [events, setEvents] = useState<CalendarEvent[]>([
    {
      start: new Date(),
      end: new Date(),
      title: 'Research Business',
      desc: 'Some description',
    },
  ]);

  const startOfDayDate = startOfDay(new Date());

  const minTime = addHours(startOfDayDate, 8);
  const maxTime = addHours(startOfDayDate, 23);

  return (
    <div className="w-full">
      <Calendar
        localizer={localizer}
        events={events}
        startAccessor="start"
        endAccessor="end"
        style={{ height: '100%' }}
        views={['week']}
        defaultView="week"
        className="text-primary-font"
        min={minTime}
        max={maxTime}
        components={{
          event: MyCustomEvent,
          day: { header: CustomHeader },
          week: { header: CustomHeader },
        }}
      />
    </div>
  );
};

export default MyWeekCalendar;


