using System.Collections.Generic;

namespace TuringMachine
{
    public static class TransitionTableGenerator
    {
        public static IEnumerable<Transition> Addition() => new[]
        {
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.Right, 0),
            new Transition(0, '1', '1', HeadDirection.Right, 1),
            new Transition(1, Head.Blank, '1', HeadDirection.Right, 2),
            new Transition(1, '1', '1', HeadDirection.Right, 1),
            new Transition(2, Head.Blank, Head.Blank, HeadDirection.Left, 3),
            new Transition(2, '1', '1', HeadDirection.Right, 2),
            new Transition(3, Head.Blank, Head.Blank, HeadDirection.Left, 3),
            new Transition(3, '1', Head.Blank, HeadDirection.Left, 4),
            new Transition(4, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(4, '1', '1', HeadDirection.Left, 4)
        };

        public static IEnumerable<Transition> Multiplication() => new[]
        {
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.Right, 1),
            new Transition(0, '1', Head.Blank, HeadDirection.Right, 2),
            new Transition(1, Head.Blank, Head.Blank, HeadDirection.Right, 14),
            new Transition(1, '1', Head.Blank, HeadDirection.Right, 2),
            new Transition(2, Head.Blank, Head.Blank, HeadDirection.Right, 3),
            new Transition(2, '1', '1', HeadDirection.Right, 2),
            new Transition(3, Head.Blank, Head.Blank, HeadDirection.Left, 15),
            new Transition(3, '1', Head.Blank, HeadDirection.Right, 4),
            new Transition(4, Head.Blank, Head.Blank, HeadDirection.Right, 5),
            new Transition(4, '1', '1', HeadDirection.Right, 4),
            new Transition(5, Head.Blank, '1', HeadDirection.Left, 6),
            new Transition(5, '1', '1', HeadDirection.Right, 5),
            new Transition(6, Head.Blank, Head.Blank, HeadDirection.Left, 7),
            new Transition(6, '1', '1', HeadDirection.Left, 6),
            new Transition(7, Head.Blank, '1', HeadDirection.Left, 9),
            new Transition(7, '1', '1', HeadDirection.Left, 8),
            new Transition(8, Head.Blank, '1', HeadDirection.Right, 3),
            new Transition(8, '1', '1', HeadDirection.Left, 8),
            new Transition(9, Head.Blank, Head.Blank, HeadDirection.Left, 10),
            new Transition(9, '1', '1', HeadDirection.Left, 9),
            new Transition(10, Head.Blank, Head.Blank, HeadDirection.Right, 12),
            new Transition(10, '1', '1', HeadDirection.Left, 11),
            new Transition(11, Head.Blank, Head.Blank, HeadDirection.Right, 0),
            new Transition(11, '1', '1', HeadDirection.Left, 11),
            new Transition(12, Head.Blank, Head.Blank, HeadDirection.Right, 12),
            new Transition(12, '1', Head.Blank, HeadDirection.Right, 13),
            new Transition(13, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(13, '1', Head.Blank, HeadDirection.Right, 13),
            new Transition(14, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(14, '1', Head.Blank, HeadDirection.Right, 14),
            new Transition(15, Head.Blank, Head.Blank, HeadDirection.Left, 16),
            new Transition(15, '1', Head.Blank, HeadDirection.Left, 15),
            new Transition(16, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(16, '1', Head.Blank, HeadDirection.Left, 16)

        };
        public static IEnumerable<Transition> Make0To1() => new[]
        {
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.Right, 1),
            new Transition(0, '1', '1', HeadDirection.Right, 1),
            new Transition(0, '0', '0', HeadDirection.Right, 1),
            new Transition(1, Head.Blank, Head.Blank, HeadDirection.Right, 1),
            new Transition(1, '1', '0', HeadDirection.Right, 2),
            new Transition(1, '0', '1', HeadDirection.Right, 2),
            new Transition(2, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(2, '1', '0', HeadDirection.Right, 2),
            new Transition(2, '0', '1', HeadDirection.Right, 2),
        };

        public static IEnumerable<Transition> MovingArrays_Task1() => new[]
        {
            new Transition(0, '0', '0', HeadDirection.NoMove, 1),
            new Transition(1, '0', '0', HeadDirection.Right, 2),
            new Transition(2, '1', '1', HeadDirection.Right, 2),
            new Transition(2, '0', '0', HeadDirection.Right, 3),
            new Transition(3, '1', '1', HeadDirection.Left, 4),
            new Transition(4, '0', '0', HeadDirection.Left, 5),
            new Transition(5, '0', '0', HeadDirection.NoMove, 13),
            new Transition(5, '1', '1', HeadDirection.Left, 6),
            new Transition(6, '1', '1', HeadDirection.Left, 6),
            new Transition(6, '0', '1', HeadDirection.Right, 7),
            new Transition(7, '1', '0', HeadDirection.Right, 8),
            new Transition(8, '1', '1', HeadDirection.Right, 8),
            new Transition(8, '0', '0', HeadDirection.Right, 9),
            new Transition(9, '1', '1', HeadDirection.Right, 9),
            new Transition(9, '0', '0', HeadDirection.Right, 10),
            new Transition(10, '1', '1', HeadDirection.Right, 10),
            new Transition(10, '0', '1', HeadDirection.Left, 11),
            new Transition(11, '1', '1', HeadDirection.Left, 11),
            new Transition(11, '0', '0', HeadDirection.Left, 12),
            new Transition(12, '1', '1', HeadDirection.Left, 12),
            new Transition(12, '0', '0', HeadDirection.NoMove, 4),
            new Transition(5, '0', '0', HeadDirection.NoMove, 13),
            new Transition(13, '0', '1', HeadDirection.Left, 14),
            new Transition(14, '1', '1', HeadDirection.Left, 14),
            new Transition(14, '0', '0', HeadDirection.Right, 15),
            new Transition(15, '1', '0', HeadDirection.NoMove, State.Halt),
        };


        public static IEnumerable<Transition>  ModuleRaznost_Task2() => new[]
        {
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.Left, 1),
            new Transition(1, '0', '9', HeadDirection.Left, 1),
            new Transition(1, '1', '0', HeadDirection.Left, 2),
            new Transition(1, '2', '1', HeadDirection.Left, 2),
            new Transition(1, '3', '2', HeadDirection.Left, 2),
            new Transition(1, '4', '3', HeadDirection.Left, 2),
            new Transition(1, '5', '4', HeadDirection.Left, 2),
            new Transition(1, '6', '5', HeadDirection.Left, 2),
            new Transition(1, '7', '6', HeadDirection.Left, 2),
            new Transition(1, '8', '7', HeadDirection.Left, 2),
            new Transition(1, '9', '8', HeadDirection.Left, 2),
            new Transition(1, '-', '-', HeadDirection.Right, 5),
            new Transition(2, Head.Blank, Head.Blank, HeadDirection.Right, 5),
            new Transition(2, '-', '-', HeadDirection.Left, 3),
            new Transition(3, Head.Blank, Head.Blank, HeadDirection.Right, 5),
            new Transition(3, '0', '9', HeadDirection.Left, 3),
            new Transition(3, '1', '0', HeadDirection.Left, 4),
            new Transition(3, '2', '1', HeadDirection.Right, 4),
            new Transition(3, '3', '2', HeadDirection.Right, 4),
            new Transition(3, '4', '3', HeadDirection.Right, 4),
            new Transition(3, '5', '4', HeadDirection.Right, 4),
            new Transition(3, '6', '5', HeadDirection.Right, 4),
            new Transition(3, '7', '6', HeadDirection.Right, 4),
            new Transition(3, '8', '7', HeadDirection.Right, 4),
            new Transition(3, '9', '8', HeadDirection.Right, 4),
            new Transition(4, Head.Blank, Head.Blank, HeadDirection.Right, 6),
            new Transition(4, '-', '-', HeadDirection.Right, 1),
            new Transition(5, '9', Head.Blank, HeadDirection.Left, 5),
            new Transition(5, '-', Head.Blank, HeadDirection.NoMove, 5),
            new Transition(5, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(6, Head.Blank, Head.Blank, HeadDirection.Right, 6),
            new Transition(6, '0', Head.Blank, HeadDirection.Right, 6),
            new Transition(6, '-', Head.Blank, HeadDirection.NoMove, 5),
        };

        public static IEnumerable<Transition> Predicat_Task3() => new[]
{
            new Transition(0, 'y', 'y', HeadDirection.NoMove, 1),
            new Transition(0, '1', '1', HeadDirection.NoMove, 1),
            new Transition(1, 'y', 'y', HeadDirection.NoMove, State.Halt),
            new Transition(1, '1', '1', HeadDirection.Right, 2),
            new Transition(2, 'y', 'y', HeadDirection.Left, 4),
            new Transition(2, '1', '1', HeadDirection.Right, 3),
            new Transition(3, 'y', 'y', HeadDirection.Left, 5),
            new Transition(3, '1', '1', HeadDirection.Right, 2),
            new Transition(4, 'y', 'y', HeadDirection.Right, 6),
            new Transition(4, '1', 'y', HeadDirection.Left, 4),
            new Transition(5, 'y', 'y', HeadDirection.Right, 0),
            new Transition(5, '1', 'y', HeadDirection.Left, 5),
            new Transition(6, 'y', '1', HeadDirection.NoMove, State.Halt),
        };


    }
}