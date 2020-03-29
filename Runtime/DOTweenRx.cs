using System;
using DG.Tweening;
using UniRx;

namespace UniGame.DOTweenRx.Runtime
{
    public static class DOTweenRx
    {
        
        static public IObservable<Tween> OnCompleteAsObservable(this Tween tweener)
        {
            return Observable.Create<Tween>(o =>
            {
                tweener.OnComplete(() =>
                {
                    o.OnNext(tweener);
                    o.OnCompleted();
                });
                return Disposable.Create(() =>
                {
                    tweener.Kill();
                });
            });
        }

        static public IObservable<Sequence> PlayAsObservable(this Sequence sequence)
        {
            return Observable.Create<Sequence>(o =>
            {
                sequence.OnComplete(() =>
                {
                    o.OnNext(sequence);
                    o.OnCompleted();
                });
                sequence.Play();
                return Disposable.Create(() =>
                {
                    sequence.Kill();
                });
            });
        }

#if true //DOTweenPro Extensions
    
        static public IObservable<DOTweenAnimation> DOPlayAsObservable(
            this DOTweenAnimation animation,
            bool rewind = false)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                if (rewind) animation.DORewind();

                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DOPlay();
                return Disposable.Empty;
            });
        }

        static public IObservable<DOTweenAnimation> DOPlayByIdAsObservable(
            this DOTweenAnimation animation,
            string id,
            bool rewind = false)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                if (rewind) animation.DORewind();

                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DOPlayById(id);
                return Disposable.Empty;
            });
        }

        static public IObservable<DOTweenAnimation> DOPlayAllByIdAsObservable(
            this DOTweenAnimation animation,
            string id,
            bool rewind = false)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                if (rewind) animation.DORewind();

                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DOPlayAllById(id);
                return Disposable.Empty;
            });
        }

        static public IObservable<DOTweenAnimation> DORestartAsObservable(
            this DOTweenAnimation animation,
            bool fromHere = false)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DORestart(fromHere);
                return Disposable.Empty;
            });
        }

        static public IObservable<DOTweenAnimation> DORestartByIdAsObservable(
            this DOTweenAnimation animation,
            string id)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DORestartById(id);
                return Disposable.Empty;
            });
        }

        static public IObservable<DOTweenAnimation> DORestartAllByIdAsObservable(
            this DOTweenAnimation animation,
            string id)
        {
            return Observable.Create<DOTweenAnimation>(o =>
            {
                animation.tween.OnComplete(() =>
                {
                    o.OnNext(animation);
                    o.OnCompleted();
                });
                animation.DORestartAllById(id);
                return Disposable.Empty;
            });
        }
        
#endif //DOTweenPro Extensions
    }
}