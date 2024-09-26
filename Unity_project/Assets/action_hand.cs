using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class action_hand : MonoBehaviour
{

    public CommandSender commandSender;
    public RotateObjectsLocal rotateObjectsLocal;
    public bool on_control;

    // Start is called before the first frame update

    private void Start()
    {
        Start_action();
    }
    void Start_action()
    {
        rotateObjectsLocal.RotateObjectOnXAxis(0, 0f);
        commandSender.SendCommand_detail(1, 1000);

        rotateObjectsLocal.RotateObjectOnXAxis(1, 0f);
        commandSender.SendCommand_detail(2, 2000);

        rotateObjectsLocal.RotateObjectOnXAxis(2, 0f);
        commandSender.SendCommand_detail(3, 2000);

        rotateObjectsLocal.RotateObjectOnXAxis(3, 0f);
        commandSender.SendCommand_detail(4, 2000);

        rotateObjectsLocal.RotateObjectOnXAxis(4, 0f);
        commandSender.SendCommand_detail(5, 2000);

        
    }

    private void FixedUpdate()
    {
        if (on_control)
        {
            StartCoroutine(DelayFunction(2f, () =>
            {
                Start_action();
                StartCoroutine(DelayFunction(2f, () =>
                {
                    Action();
                }));
            }));

            on_control = false;
        }
    }

    void Action()
    {

        rotateObjectsLocal.RotateObjectOnXAxis(0, 90f);
        commandSender.SendCommand_detail(1, 1900);

        StartCoroutine(DelayFunction(2f, () =>
        {
            rotateObjectsLocal.RotateObjectOnXAxis(1, 90f);
            commandSender.SendCommand_detail(2, 1000);

            StartCoroutine(DelayFunction(2f, () =>
            {
                rotateObjectsLocal.RotateObjectOnXAxis(2, 90f);
                commandSender.SendCommand_detail(3, 1000);

                StartCoroutine(DelayFunction(2f, () =>
                {
                    rotateObjectsLocal.RotateObjectOnXAxis(3, 90f);
                    commandSender.SendCommand_detail(4, 1000);

                    StartCoroutine(DelayFunction(2f, () =>
                    {
                        rotateObjectsLocal.RotateObjectOnXAxis(4, 90f);
                        commandSender.SendCommand_detail(5, 1000);

                        StartCoroutine(DelayFunction(2f, () =>
                        {
                            // 可以继续添加延时执行的操作或其他逻辑
                            rotateObjectsLocal.RotateObjectOnXAxis(0, 0f);
                            commandSender.SendCommand_detail(1, 1000);

                            rotateObjectsLocal.RotateObjectOnXAxis(1, 0f);
                            commandSender.SendCommand_detail(2, 2000);

                            rotateObjectsLocal.RotateObjectOnXAxis(2, 0f);
                            commandSender.SendCommand_detail(3, 2000);

                            rotateObjectsLocal.RotateObjectOnXAxis(3, 0f);
                            commandSender.SendCommand_detail(4, 2000);

                            rotateObjectsLocal.RotateObjectOnXAxis(4, 0f);
                            commandSender.SendCommand_detail(5, 2000);

                            StartCoroutine(DelayFunction(2f, () =>
                            {
                                rotateObjectsLocal.RotateObjectOnXAxis(0, 90f);
                                commandSender.SendCommand_detail(1, 2000);

                                rotateObjectsLocal.RotateObjectOnXAxis(1, 90f);
                                commandSender.SendCommand_detail(2, 1000);

                                rotateObjectsLocal.RotateObjectOnXAxis(2, 90f);
                                commandSender.SendCommand_detail(3, 1000);

                                rotateObjectsLocal.RotateObjectOnXAxis(3, 90f);
                                commandSender.SendCommand_detail(4, 1000);

                                rotateObjectsLocal.RotateObjectOnXAxis(4, 90f);
                                commandSender.SendCommand_detail(5, 1000);
                            }));
                         }));
                    }));
                }));
            }));
        }));
    }

    IEnumerator DelayFunction(float delay_time, Action onComplete)
    {
        yield return new WaitForSeconds(delay_time);

        onComplete?.Invoke();
    }



}
