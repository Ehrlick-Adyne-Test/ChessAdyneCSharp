namespace ChessAdyne {
    class MoveRule {
        private int xStep;
        private int yStep;

        public MoveRule(int _xStep, int _yStep) {
            this.xStep = _xStep;
            this.yStep = _yStep;
        }

        public int getXStep() {
            return xStep;
        }

        public int getYStep() {
            return yStep;
        }

        public override string ToString() {
            return $"MoveRule: x[{xStep}] y[{yStep}]";
        } 
    }
}