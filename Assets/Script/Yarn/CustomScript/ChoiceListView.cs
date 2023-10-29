using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ChoiceListView : DialogueViewBase
{
    //[SerializeField] CanvasGroup canvasGroup;

    [SerializeField] ChoiceView optionViewPrefab;

    [SerializeField] TextMeshProUGUI lastLineText;

    [SerializeField] float fadeTime = 0.1f;

    [SerializeField] bool showUnavailableOptions = false;

    // A cached pool of OptionView objects so that we can reuse them
    List<ChoiceView> optionViews = new List<ChoiceView>();

    // The method we should call when an option has been selected.
    Action<int> OnOptionSelected;

    public DialogueView dialogueView;

    // The line we saw most recently.
    LocalizedLine lastSeenLine;

    public GameObject recordObject;
    public int selectedId ;
    public int lastId ;
    public DialogueOption selectedOption;

    public void Start()
    {
        selectedId = -1;
        lastId = -1;
    }

    //public void Reset()
    //{
    //    canvasGroup = GetComponentInParent<CanvasGroup>();
    //}

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
            // Don't do anything with this line except note it and
            // immediately indicate that we're finished with it. RunOptions
            // will use it to display the text of the previous line.
        lastSeenLine = dialogueLine;
        onDialogueLineFinished();
    }

    public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
    {
            // Hide all existing option views
        foreach (var optionView in optionViews)
        {
            optionView.gameObject.SetActive(false);
        }

            // If we don't already have enough option views, create more
        while (dialogueOptions.Length > optionViews.Count)
        {
            var optionView = CreateNewOptionView();
            optionView.gameObject.SetActive(false);
        }

        dialogueView.gameObject.GetComponent<Button>().enabled = false;

        // Set up all of the option views
        int optionViewsCreated = 0;
        this.gameObject.GetComponent<ChoicePos>().SetChoicePos();

        for (int i = 0; i < dialogueOptions.Length; i++)
        {
            var optionView = optionViews[i];
            var option = dialogueOptions[i];
            if (option.IsAvailable == false && showUnavailableOptions == false)
            {
                // Don't show this option.
                continue;
            }

            optionView.gameObject.SetActive(true);

            optionView.Option = option;

            // The first available option is selected by default
            if (optionViewsCreated == 0)
            {
                optionView.Select();
            }

            optionViewsCreated += 1;
        }

            // Update the last line, if one is configured
        if (lastLineText != null)
        {
            if (lastSeenLine != null)
            {
                lastLineText.gameObject.SetActive(true);
                lastLineText.text = lastSeenLine.Text.Text;
            }
            else
            {
                lastLineText.gameObject.SetActive(false);
            }
        }

            // Note the delegate to call when an option is selected
        OnOptionSelected = onOptionSelected;

            // Fade it all in
            //StartCoroutine(Effects.FadeAlpha(canvasGroup, 0, 1, fadeTime));

            /// <summary>
            /// Creates and configures a new <see cref="OptionView"/>, and adds
            /// it to <see cref="optionViews"/>.
            /// </summary>
         ChoiceView CreateNewOptionView()
         {
            var optionView = Instantiate(optionViewPrefab);
            optionView.transform.SetParent(transform, false);
            optionView.transform.SetAsLastSibling();

            optionView.OnOptionSelected = OptionViewWasSelected;
            optionViews.Add(optionView);

            return optionView;
         }

            /// <summary>
            /// Called by <see cref="OptionView"/> objects.
            /// </summary>
        void OptionViewWasSelected(DialogueOption option)
        {
            //此处获取了返回的ID并执行了，在choiceview返回值前，将值传到计算，再传回这里。
            //调用这个就会进图下一句
            selectedId = option.DialogueOptionID;
            selectedOption = option;
            
            if(lastId != selectedId)
            {   if(lastId != -1)
                {
                    optionViews[lastId].gameObject.GetComponent<Image>().enabled = false;
                }
                optionViews[selectedId].gameObject.GetComponent<Image>().enabled = true;
            }
            lastId = selectedId;
            //    OnOptionSelected(option.DialogueOptionID);
            //foreach (var optionView in optionViews)
            //{
            //    optionView.gameObject.SetActive(false);
            //}
            //StartCoroutine(OptionViewWasSelectedInternal(option));

            //IEnumerator OptionViewWasSelectedInternal(DialogueOption selectedOption)
            //{
            //    yield return StartCoroutine(Effects.FadeAlpha(canvasGroup, 1, 0, fadeTime));
            //    OnOptionSelected(selectedOption.DialogueOptionID);
            //}
        }
    }
    public void subimtChoice()
    {
        dialogueView.gameObject.GetComponent<Button>().enabled = true;
        OnOptionSelected(selectedId);
        optionViews[selectedId].gameObject.GetComponent<Image>().enabled = false;
        selectedId = -1;
        foreach (var optionView in optionViews)
        {
            optionView.gameObject.SetActive(false);
        }
    }

    /// <inheritdoc />
    /// <remarks>
    /// If options are still shown dismisses them.
    /// </remarks>
    public override void DialogueComplete()
    {
         StopAllCoroutines();
         lastSeenLine = null;
         OnOptionSelected = null;
            // do we still have any options being shown?
            //if (canvasGroup.alpha > 0)
            //{
            //    StopAllCoroutines();
            //    lastSeenLine = null;
            //    OnOptionSelected = null;
            //    canvasGroup.interactable = false;
            //    canvasGroup.blocksRaycasts = false;

            //    StartCoroutine(Effects.FadeAlpha(canvasGroup, canvasGroup.alpha, 0, fadeTime));
            //}
    }
}

