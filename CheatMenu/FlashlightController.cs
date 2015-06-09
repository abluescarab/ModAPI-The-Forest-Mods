using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Items.World;

namespace CheatMenu {
    class FlashlightController : BatteryBasedLight {
        protected float baseBatteryCost;
        protected bool  batteryCostSet = false;

        protected void BaseValues() {
            // only lets the variable be set once
            if(!batteryCostSet) {
                this.baseBatteryCost = this._batterieCostPerSecond;
                this.batteryCostSet = true;
            }
            
            ModAPI.Log.Write("Battery cost/second: " + this._batterieCostPerSecond.ToString());
        }

        protected override void OnEnable() {
            BaseValues();

            if(CheatMenuComponent.UnlimitedFlashlight) {
                this._batterieCostPerSecond = 0;
            }
            else {
                this._batterieCostPerSecond = baseBatteryCost;
            }
            
            base.OnEnable();
        }
    }
}
