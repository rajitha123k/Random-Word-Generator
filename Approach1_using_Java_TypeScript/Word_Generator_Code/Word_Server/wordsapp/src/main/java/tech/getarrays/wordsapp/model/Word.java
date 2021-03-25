package tech.getarrays.wordsapp.model;

import javax.persistence.*;
import java.io.Serializable;

@Entity
public class Word implements Serializable{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long id;
    private String command;

    public Word() {}

    public Word(String command) {
        this.command = command;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getCommand() {
        return command;
    }

    public void setCommand(String command) {
        this.command = command;
    }


    @Override
    public String toString() {
        return "Words{" +
                "id=" + id +
                ", command='" + command + '\'' +
                '}';
    }
}
