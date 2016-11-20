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
            Right = 1
        };

        // Left or Right d-pad pressed
        private bool[] dPadInput;
        public bool[] DPadInput
        {
            get { return dPadInput; }
        }

        public enum btn_act {
            Jump = 0,
            Roll = 1
        };
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

        // Public constructors
        public Q_State (bool[] d_pad_state,
                        bool[] action_state,
                        bool[] v_vec, 
                        bool[] enemy_dists, 
                        bool stuck_bit,
                        bool dead_bit)
        {
            init(d_pad_state, action_state, v_vec, enemy_dists,
                    stuck_bit, dead_bit);
        }

        public Q_State(Q_State qstate)
        {
            init(qstate.dPadInput, qstate.actions, 
                    qstate.velVector, qstate.enemies,
                    qstate.stuck, qstate.dead);
        }

        void init(bool[] d_pad_state,
                  bool[] action_state,
                  bool[] v_vec,
                  bool[] enemy_dists,
                  bool stuck_bit,
                  bool dead_bit)
        {
            dPadInput = d_pad_state;
            actions = action_state;
            velVector = v_vec;
            enemies = enemy_dists;
            stuck = stuck_bit;
            dead = dead_bit;
        }
    }

    class RLAgent
    {
        Dictionary<Q_State, int> visited_states;

        public RLAgent()
        {
            visited_states = new Dictionary<Q_State, int>();
        }


    }
}
