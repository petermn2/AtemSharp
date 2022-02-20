using System.Windows;
using System.Runtime.InteropServices;
using BMDSwitcherAPI;

namespace AtemSharp
{
    public delegate void SwitcherEventHandler();

    class SwitcherCallback : IBMDSwitcherCallback
    {
        public event SwitcherEventHandler SwitcherDisconnected;

        public void SwitcherMonitor()
        {
        }

        void IBMDSwitcherCallback.Notify(_BMDSwitcherEventType eventType, _BMDSwitcherVideoMode coreVideoMode)
        {
            if (eventType == _BMDSwitcherEventType.bmdSwitcherEventTypeDisconnected)
            {
                if (SwitcherDisconnected != null)
                    SwitcherDisconnected();
            }
        }
    }

    class MixEffectBlockCallback : IBMDSwitcherMixEffectBlockCallback
    {
        // Events:
        public event SwitcherEventHandler ProgramInputChanged;
        public event SwitcherEventHandler PreviewInputChanged;
        public event SwitcherEventHandler TransitionFramesRemainingChanged;
        public event SwitcherEventHandler TransitionPositionChanged;
        public event SwitcherEventHandler InTransitionChanged;
        public MixEffectBlockCallback() 
        {
        }

        void IBMDSwitcherMixEffectBlockCallback.Notify(_BMDSwitcherMixEffectBlockEventType eventType)
        {
            switch (eventType)
            {
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeProgramInputChanged:
                    if (ProgramInputChanged != null)
                        ProgramInputChanged();
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypePreviewInputChanged:
                    if (PreviewInputChanged != null)
                        PreviewInputChanged();
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeTransitionFramesRemainingChanged:
                    if (TransitionFramesRemainingChanged != null)
                        TransitionFramesRemainingChanged();
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeTransitionPositionChanged:
                    if (TransitionPositionChanged != null)
                        TransitionPositionChanged();
                    break;
                case _BMDSwitcherMixEffectBlockEventType.bmdSwitcherMixEffectBlockEventTypeInTransitionChanged:
                    if (InTransitionChanged != null)
                        InTransitionChanged();
                    break;
            }
        }


    }

    class InputCallback : IBMDSwitcherInputCallback
    {
        public event SwitcherEventHandler LongNameChanged;

        private IBMDSwitcherInput bInput;
        public IBMDSwitcherInput Input { get { return bInput; } }

        public InputCallback(IBMDSwitcherInput input)
        {
            bInput = input;
        }

        void IBMDSwitcherInputCallback.Notify(_BMDSwitcherInputEventType eventType)
        {
            switch (eventType)
            {
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeLongNameChanged:
                    if (LongNameChanged != null)
                        LongNameChanged();
                    break;
            }
        }
        //       void IBMDSwitcherInputCallback.PropertyChanged(_BMDSwitcherInputPropertyId propertyId)
        //       {
        //           switch (propertyId)
        //           {
        //               case _BMDSwitcherInputPropertyId.bmdSwitcherInputPropertyIdLongName:
        //                   if (LongNameChanged != null)
        //                       LongNameChanged();
        //                   break;
        //           }
    }
    
}
