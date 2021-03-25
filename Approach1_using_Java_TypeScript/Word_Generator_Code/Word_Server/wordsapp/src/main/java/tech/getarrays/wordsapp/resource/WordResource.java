package tech.getarrays.wordsapp.resource;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import tech.getarrays.wordsapp.service.WordService;
import tech.getarrays.wordsapp.model.Word;

import java.util.List;

@RestController
@RequestMapping("/word")
public class WordResource {
    private final WordService employeeService;
    Word word= new Word();
    public WordResource(WordService employeeService) {
        this.employeeService = employeeService;
    }

    @GetMapping("/all")
    public ResponseEntity<List<String>> getAllWords () {
        List<String> words = employeeService.getAllWords();
        word.setCommand("GET");
        Word w=employeeService.addToDB(word);
        return new ResponseEntity<>(words, HttpStatus.OK);
    }

    @GetMapping("/nochange")
    public ResponseEntity<List<String>> getWordsNoChange () {
        List<String> wordsno = employeeService.getWordsNoChange();
        word.setCommand("GET");
        Word wo=employeeService.addToDB(word);
        return new ResponseEntity<>(wordsno, HttpStatus.OK);
    }

    @PostMapping("/add")
    public ResponseEntity<List<String>> addWord(@RequestBody String name) {
        List<String> namelist= employeeService.addWord(name);
        word.setCommand("POST");
        Word w1=employeeService.addToDB(word);
        return new ResponseEntity<>(namelist, HttpStatus.CREATED);
    }
}
