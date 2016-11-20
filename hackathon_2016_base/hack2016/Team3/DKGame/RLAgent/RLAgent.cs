using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKGame
{
    public class Q_State{

        public enum dpad
        {
            Left = 0,
            Right = 1,
            Jump = 2,
            Roll = 3
        };

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

        //used to access 8-way velocity vector
        public enum vec_dir
        {
            Up = 0,
            Up_Right = 1,
            Right = 2,
            Right_Down = 3,
            Down = 4,
            Down_Left = 5,
            Left = 6,
            Up_Left = 7
        };
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
        }
        private bool dead;
        public bool Dead
        {
            get { return dead; }
        }
        private float reward;
        public float Reward
        {
            get { return reward; }
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

        public Q_State(Q_State qstate)
        {
            init(qstate.ctrlInput, qstate.actions, 
                    qstate.velVector, qstate.enemies,
                    qstate.stuck, qstate.dead,
                    qstate.Reward);
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
            reward = rwd;
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


        public void UpdateStates(Q_State nxtState)
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
            //update algorithm

            visitedStates[currState] = (1 - learningRate) * visitedStates[currState] +
                                            (learningRate * (currState.Reward + discountFact * MaxNxtAction()));

        }

        public Enum TakeAction()
        {

        }

        public Q_State MaxNextAction()
        {

        }
    }
}
