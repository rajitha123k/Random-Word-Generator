package tech.getarrays.wordsapp.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import tech.getarrays.wordsapp.repo.WordRepo;
import tech.getarrays.wordsapp.model.Word;
import javax.transaction.Transactional;
import java.util.*;

@Service
@Transactional
public class WordService {

    public List<String> namelist=new ArrayList<>();
    public List<String> namelistchanged=new ArrayList<>();
    private final WordRepo wordRepo;

    @Autowired
    public WordService(WordRepo wordRepo) {
        this.wordRepo = wordRepo;
    }

    public List<String> addWord(String name) {
        namelist.add(name);
        return namelist;
    }

    public List<String> getAllWords() {
        namelistchanged.addAll(namelist);
        Collections.shuffle(namelistchanged);
        return namelistchanged;
    }
    public List<String> getWordsNoChange() {
        return namelist;
    }
    public Word addToDB(Word word){
        return wordRepo.save(word);
    }
}
