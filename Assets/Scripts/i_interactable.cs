public interface i_interactable
{
    float maxrange { get; }

    void onstarthover();
    void oninteraction();
    void onendhover();
        
}