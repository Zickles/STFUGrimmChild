using Modding;
using System;
using UnityEngine;

namespace STFUGrimmChild
{
    public class STFUGrimmChildMod : Mod
    {
        private static STFUGrimmChildMod? _instance;

        internal static STFUGrimmChildMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(STFUGrimmChildMod)} was never constructed");
                }
                return _instance;
            }
        }

        public override string GetVersion() => "1.0.0.0";

        public STFUGrimmChildMod() : base("STFUGrimmChild")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;

            Log("Initialized");
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);
            if (self.gameObject.tag == "Grimmchild" && self.FsmName == "Control")
            {
                GameObject.Find("Grimmchild(Clone)").transform.Find("Voice Loop").gameObject.SetActive(false);
            }
        }
    }
}
