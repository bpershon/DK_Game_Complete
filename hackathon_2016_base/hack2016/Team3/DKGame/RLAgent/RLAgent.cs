using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class Q_State{

        // 4 booleans accessed by dpad enums
        private bool[] ctrlInput;
        public bool[] CtrlInput
        {
            get { return ctrlInput; }
        }
        /* 
            Jump or Roll button pressed
                only one can be pressed at a time
            Usage actions[(int)btn_act.jump]
        */
        private bool[] actions;
        public bool[] Actions
        {
            get { return actions; }
        }

        // Usage vel_vector[ (int)vec_dir.[direction] ]
        private bool[] velVector;
        public bool[] VelVector
        {
            get { return velVector; }
        }

        /*
            enemy queue
                -0 danger
                -1 close
                -2 far
                -3 edge of screen 
        */
        private bool[] enemies;
        public bool[] Enemies
        {
            get { return Enemies; }
        }
        private bool stuck;
        public bool Stuck
        {
            get { return stuck; }
            set { stuck = value; }
        }
        private bool dead;
        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }

        public const float TERMINAL_POS = 1;
        public const float TERMINAL_NEG = -1;
        public const float NON_TERMINAL = -0.4f;

        private float reward;
        public float Reward
        {
            get { return reward; }
        }

        private int timesSeen = 1;
        public int TimesSeen
        {
            get { return timesSeen; }
            set { timesSeen = value; }
        }

        // Public constructors
        public Q_State (bool[] d_pad_state,
                        bool[] action_state,
                        bool[] v_vec, 
                        bool[] enemy_dists, 
                        bool stuck_bit,
                        bool dead_bit, 
                        float rwd)
        {
            init(d_pad_state, action_state, v_vec, enemy_dists,
                    stuck_bit, dead_bit, rwd);
        }

        public Q_State()
        {
            ctrlInput = new bool[4];
            velVector = new bool[8];
            enemies = new bool[4];
            dead = false;
            stuck = false;
        }

        public Q_State(Q_State qstate)
        {
            init(qstate.ctrlInput, qstate.actions, 
                    qstate.velVector, qstate.enemies,
                    qstate.stuck, qstate.dead, qstate.reward);
        }

        void init(bool[] d_pad_state,
                  bool[] action_state,
                  bool[] v_vec,
                  bool[] enemy_dists,
                  bool stuck_bit,
                  bool dead_bit,
                  float rwd)
        {
            ctrlInput = d_pad_state;
            actions = action_state;
            velVector = v_vec;
            enemies = enemy_dists;
            stuck = stuck_bit;
            dead = dead_bit;
            rwd = reward;
        }
    }

    class RLAgent
    {
        private Dictionary<Q_State, float> visitedStates;
        private Q_State currState;
        private float learningRate;
        private float discountFact;

        //Public constructor
        public RLAgent(float learnRate, float discFact)
        {
            visitedStates = new Dictionary<Q_State, float>();
            learningRate = learnRate;
            discountFact = discFact;
        }


        public void UpdateState(Q_State nxtState)
        {
            if(nxtState == null)
            {
                return;
            }

            currState = nxtState;

            if (visitedStates[currState] > 0)
            {
                // Update number of times nodes visited?
            }
            else
            {
                visitedStates.Add(currState, 0);
            }
        }

        public void UpdatePolicy()
        {

        }

        public Enum TakeAction()
        {

        }

        public Q_State MaxNextAction()
        {

        }
    }
}
