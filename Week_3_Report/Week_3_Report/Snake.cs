using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Report
{
    public class Snake
    {
        #region Member Variables
        /* <Linked List> vs <List>
         * 먹이를 계속 먹으면서 가변적으로 메모리 길이가 변하는 형태는
         * 동적 배열을 사용하는 List보다 노드 방식으로 공간복잡도가 O(1)인 LinkedList가 좋다.
         */
        private LinkedList<Point> _snake;
        private E_Direction _direction;
        #endregion

        #region Constructor & Destructor
        public Snake(Point initStartPoint, int initSnakeSize, E_Direction initSnakeDirection)
        {
            _snake = new LinkedList<Point>();
            _direction = initSnakeDirection;

            this.SnakeInitialize(initStartPoint, initSnakeSize);
        }
        #endregion

        #region Main Methods
        public void Movement()
        {
            Point head = _snake.First();
            int prevX = head.X;
            int prevY = head.Y;

            switch(_direction)
            {
                case E_Direction.LEFT:
                    head.X -= 1;
                    break;
                case E_Direction.RIGHT:
                    head.X += 1;
                    break;
                case E_Direction.UP:
                    head.Y -= 1;
                    break;
                case E_Direction.DOWN:
                    head.Y += 1;
                    break;
            }

            foreach (Point body in _snake)
            {
                if (body == head)
                    continue;

                int bodyX = body.X;
                int bodyY = body.Y;

                body.X = prevX;
                body.Y = prevY;

                prevX = bodyX;
                prevY = bodyY;
            }

            Helper.PrintClearSymbol(prevX, prevY);
            this.Draw();
        }

        public bool IsHitFood(Point food)
        {
            char headSymbol = _snake.First().Symbol;
            char bodySymbol = _snake.Last().Symbol;

            Point nextHead = GetHeadNextPosition();

            if (nextHead.IsHit(food))
            {
                food.Symbol = headSymbol;

                _snake.First().Symbol = bodySymbol;
                _snake.AddFirst(food);

                return true;
            }

            return false;
        }

        public bool IsHitBody()
        {
            Point head = _snake.First();

            foreach (Point body in _snake)
            {
                if (body == head)
                    continue;

                if (head.IsHit(body))
                    return true;
            }

            return false;
        }

        public bool IsHitBorder(StageLevel level)
        {
            Point head = _snake.First();

            if ((head.X <= level.LevelBlankUnit || head.X >= level.LevelWidth) ||
                (head.Y <= level.LevelBlankUnit || head.Y >= level.LevelHeight))
                return true;
            return false;
        }
        #endregion

        #region Helper Methods
        void SnakeInitialize(Point initStartPoint, int initSnakeSize)
        {
            for (int i = 0; i < initSnakeSize; ++i)
            {
                Point startPos = new Point(initStartPoint.X, initStartPoint.Y, initStartPoint.Symbol);

                switch (_direction)
                {
                    case E_Direction.LEFT:
                        startPos.X += i;
                        break;
                    case E_Direction.RIGHT:
                        startPos.X -= i;
                        break;
                    case E_Direction.UP:
                        startPos.Y += i;
                        break;
                    case E_Direction.DOWN:
                        startPos.Y -= i;
                        break;
                }

                if (_snake.Count == 0)
                    startPos.Symbol = Helper.g_SnakeHeadSymbol;

                // 뱀의 머리 ~ 발 순으로 넣어준다.
                _snake.AddLast(startPos);
            }

            //_snakeHead = _snake.First();
            //_snakeTail = _snake.Last();
        }

        public void MovementInput()
        {
            // 키 입력이 있는 경우에만 true를 반환한다.
            if (Console.KeyAvailable)
            {
                var inputKey = Console.ReadKey(true).Key;

                switch (inputKey)
                {
                    case ConsoleKey.LeftArrow:
                        if (_direction != E_Direction.RIGHT)
                            _direction = E_Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        if (_direction != E_Direction.LEFT)
                            _direction = E_Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        if (_direction != E_Direction.DOWN)
                            _direction = E_Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        if (_direction != E_Direction.UP)
                            _direction = E_Direction.DOWN;
                        break;
                }
            }
        }

        //public void GetHeadNextPosition(out int posX, out int posY)
        //{
        //    Point head = _snake.First();
        //    int x = head.X;
        //    int y = head.Y;

        //    switch (_direction)
        //    {
        //        case E_Direction.LEFT:
        //            x = head.X - 1;
        //            break;
        //        case E_Direction.RIGHT:
        //            x = head.X + 1;
        //            break;
        //        case E_Direction.UP:
        //            y = head.Y - 1;
        //            break;
        //        case E_Direction.DOWN:
        //            y = head.Y + 1;
        //            break;
        //    }

        //    posX = x;
        //    posY = y;
        //}

        public Point GetHeadNextPosition()
        {
            Point head = _snake.First();
            Point nextHead = new Point(head);

            switch (_direction)
            {
                case E_Direction.LEFT:
                    nextHead.X -= 1;
                    break;
                case E_Direction.RIGHT:
                    nextHead.X += 1;
                    break;
                case E_Direction.UP:
                    nextHead.Y -= 1;
                    break;
                case E_Direction.DOWN:
                    nextHead.Y += 1;
                    break;
            }

            return nextHead;
        }

        public void Draw()
        {
            foreach(Point snake in _snake)
                snake.Draw();
        }
        #endregion
    }
}
