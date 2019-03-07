using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstsEnums;



public class InputHandler : MonoBehaviour {
   
    public class InputSettingValue<VALUE>
    {
        public InputSettings Key;
        public VALUE Value;

        public InputSettingValue() { }

        public InputSettingValue(InputSettings key, VALUE val)
        {
            this.Key = key;
            this.Value = val;
        }
    }

    public float DpadDeadTime = 0.1f;
    public KeyValueData keyValues;
    private float deadBuf = 0.0f;
    private List<InputSettingValue<float>> axises;
    private List<InputSettingValue<bool>> buttons;

    public float getAxis(InputSettings input) {
        return axises.Find(x => x.Key == input).Value;
    }

    public bool getButtonDown(InputSettings input) {
        return buttons.Find(x => x.Key ==  input).Value;
    }

    void Start()
    {
        axises = new List<InputSettingValue<float>>();
        buttons = new List<InputSettingValue<bool>>();
        for (int i = 0; i < keyValues.KeyValues.Count; i++)
        {
            KeyPair item = keyValues.KeyValues[i];
            if ((item.Key == InputSettings.LOOKX) ||
                (item.Key == InputSettings.LOOKY) ||
                (item.Key == InputSettings.MOVEX) ||
                (item.Key == InputSettings.MOVEY)){
                    axises.Add(new InputSettingValue<float>(item.Key, 0.0f));
                    continue;
            }
            buttons.Add(new InputSettingValue<bool>(item.Key, false));
        }
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < axises.Count; i++)
        {
            var item = axises[i];
            item.Value = Input.GetAxis(keyValues.KeyValues.Find(x => x.Key == item.Key).Value);
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            var item = buttons[i];
            string inputKey = keyValues.KeyValues.Find(x => x.Key == item.Key).Value;
            if ((inputKey == Controller.DPADDown) ||
                (inputKey == Controller.DPADUp) ||
                (inputKey == Controller.DPADRight) ||
                (inputKey == Controller.DPADLeft) ) {
                item.Value = DPADConvert(inputKey); 
            }
            else
                item.Value = Input.GetButtonDown(keyValues.KeyValues.Find(x => x.Key == item.Key).Value);
        }
    }

    private bool DPADConvert(string dpad) {
        float dpadX = Input.GetAxis(Controller.DPADX);
        float dpadY = Input.GetAxis(Controller.DPADY);

        if (Mathf.Abs(dpadX) > 0.5f || Mathf.Abs(dpadY) > 0.5f) {
            deadBuf += Time.deltaTime;
            if (deadBuf < DpadDeadTime){
                return false;
            }
            else deadBuf = 0.0f;
        }
        switch (dpad) {
            case Controller.DPADDown:   if (dpadY < -0.5f) return true; break;
            case Controller.DPADUp: if (dpadY > 0.5f) return true; break;
            case Controller.DPADRight: if (dpadX > 0.5f) return true; break;
            case Controller.DPADLeft: if (dpadX < -0.5f) return true; break;
            default: return false;
        }
        return false;
    }
}
