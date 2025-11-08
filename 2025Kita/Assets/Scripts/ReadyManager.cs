using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Pause pause;
    [SerializeField] private StageCamera sc;

    private static bool reload = false;

    private IEnumerator Start()
    {
        if (reload)
        {
            text.text = "";
            Time.timeScale = 1f;
            if(player != null)
            {
                player.ready = true;
            }
        }
        else
        {
            if (sc != null)
            {
                yield return StartCoroutine(sc.IntroCamera());
            }
            if(text != null)
            {
                yield return StartCoroutine(ShowPurpose());
                yield return StartCoroutine(ReadyStart());
            }
        }
    }

    //�X�^�[�g�O�̃J�E���g�_�E��
    private IEnumerator ReadyStart()
    {
        int count = 3;

        Time.timeScale = 0;

        if(player != null)
        {
            player.ready = false;
        }

        //�Q�[���J�n�܂őҋ@���Ă���Ԃ̏���
        while(count > 0)
        {
            text.text = "Ready...";
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        yield return new WaitUntil(() => !pause.isPaused);

        //�Q�[���J�n�����Ƃ��̏���
        text.text = "Start!";
        yield return new WaitForSecondsRealtime(1f);
        text.gameObject.SetActive(false);

        Time.timeScale = 1;

        if (player != null)
        {
            player.ready = true;
        }

            //�V�[����1�x�ǂݍ���ł���
            reload = true;

    }

    //�X�^�[�g�O�̖ړI�\��
    private IEnumerator ShowPurpose()
    {
        int count = 3;
        Time.timeScale = 0;

        while(count > 0)
        {
            text.text = "フライパンに飛び込め！";
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
        
    }

    //�����x�V�[����ǂݍ��ނ�
    public static void ResetReady()
    {
        reload = false;
    }

    //�X�L�b�v�{�^���������ꂽ��
    public void SkipCamera()
    {
        sc.skip = true;
    }
}
