using System;
using System.Collections.Generic;
using System.Linq;

namespace TuringMachine
{
    public class Machine
    {
        public Machine(int state, Head head, IEnumerable<Transition> transitionTable)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            if (transitionTable == null) throw new ArgumentNullException(nameof(transitionTable));

            State = state;
            Head = head;
            TransitionTable = transitionTable;
        }

        public int State { get; }

        public Head Head { get; }

        public IEnumerable<Transition> TransitionTable { get; }

        public Machine Step()
        {
            if (State < 0) return this;

            return
                TransitionTable
                    .Where(t => t.InitialState == State && t.Read == Head.Read())
                    .DefaultIfEmpty(new Transition(0, Head.Blank, Head.Read(), HeadDirection.NoMove,
                        TuringMachine.State.Error))
                    .Select(
                        t => new Machine(t.NextState, Head.Write(t.Write).Move(t.HeadDirection), TransitionTable))
                    .First();
        }

        public Machine Run()
        {
            var m = this;
            var TableFormat = new TableFormat();
            Console.WriteLine($"{"\nНачальное состояние ленты: " + m.Head + "\n"}");
            TableFormat.PrintLine();
            TableFormat.PrintRow("Шаг", "Состояние", "Лента");
            TableFormat.PrintLine();
            var count = 0;

            while (m.State >= 0)
            {
                m = m.Step();
                count++;
                TableFormat.PrintRow(count.ToString(), m.State.ToString(), m.Head.ToString());
                TableFormat.PrintLine();
            }

            Console.WriteLine($"{"\nКонечное состояние ленты: " + m.Head}");
            return m;
        }
    }
}